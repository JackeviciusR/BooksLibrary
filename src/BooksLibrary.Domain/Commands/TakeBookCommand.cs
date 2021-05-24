using BooksLibrary.Domain.Extensions;
using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Commands
{
    public class TakeBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private IEnumerable<Book> books;

        public TakeBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Run()
        {
            var books = _fileService.GetAll();
            var book = TakeBook(books);

            books = DeleteBook(books, book.ISBN);
            books = books.Append(book);

            _fileService.Overwrite(books);
            _writer.WriteLine($"Success! Book: {book.Name} (ISBN: {book.ISBN}) is in your bag!");
        }

        public List<Book> DeleteBook(IEnumerable<Book> books, string bookISBN)
        {
            return books.Where(b => b.ISBN != bookISBN).ToList();
        }

        public Book TakeBook(IEnumerable<Book> books)
        {
            int clientId = 0; ;

            try
            {
                clientId = Int32.Parse(_writer.ReadLine($"Enter clientID:"));
            }
            catch(Exception)
            {
                _writer.WriteLine($"ClientId must be number!");
            }

            var clientBooksList = books.Where(b => b.ClientId == clientId).ToList();

            if (clientBooksList.Count() < 3)
            {
                var bookISBN = _writer.ReadLine($"Enter book ISBN (Your are taken { clientBooksList.Count() } books):");
            
                var book = books.FirstOrDefault(b => b.ISBN == bookISBN);

                if (book == null)
                {
                    throw new ArgumentException("\nWe do not have this book! :(");
                }
                else if (book.ClientId != null) 
                {
                    throw new ArgumentException("\nThis book is not free! :(");
                }

                return book.UpdateBookCheckIn(clientId);
            }
            else
            {
                throw new ArgumentException("\nYou can not take mare than 3 books! :(");
            }

        }

   

        
    }
}
