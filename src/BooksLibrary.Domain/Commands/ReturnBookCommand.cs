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
    public class ReturnBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private IEnumerable<Book> books;


        public ReturnBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Run()
        {
            books = _fileService.GetAll();
            var book = ReturnBook(books);

            books = DeleteBook(books, book.ISBN);
            books = books.Append(book);

            _fileService.Overwrite(books);
            _writer.WriteLine($"Success! Book: {book.Name} (ISBN: {book.ISBN}) is put in Library!");
        }

        public Book ReturnBook(IEnumerable<Book> books)
        {
            int clientId = 0; ;

            try
            {
                clientId = Int32.Parse(_writer.ReadLine($"Enter clientID:"));
            }
            catch (Exception)
            {
                _writer.WriteLine($"ClienId must be number!");
            }

            var clientBooksList = books.Where(b => b.ClientId == clientId).ToList();


            if (clientBooksList.Count() > 0)
            {
                _writer.WriteLine($"Your books:");

                foreach (var listBook in clientBooksList)
                {
                    _writer.WriteLine($"ISBN: {listBook.ISBN}, book name: {listBook.Name}");
                }

                var bookISBN = _writer.ReadLine($"Enter book ISBN (Your are taken { clientBooksList.Count() } books):");

                var book = books.FirstOrDefault(b => b.ISBN == bookISBN);

                if (book == null || book.ClientId != clientId)
                {
                    throw new ArgumentException("\nYou do not have this book, and maybe we do not have :)). Try again!");
                }

                if (book.DeadlineDate < DateTime.Now)
                {
                    _writer.WriteLine($"Late!!! You probably enjoyed reading it :)");
                }

                return book.UpdateBookCheckOut(clientId);
            }
            else
            {
                throw new ArgumentException("\nYou do not have books! You could take some :)");
            }

        }

        public List<Book> DeleteBook(IEnumerable<Book> books, string bookISBN)
        {
            return books.Where(b => b.ISBN != bookISBN).ToList();
        }

    }
}
