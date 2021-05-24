using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Services
{
    public class PrintService : IPrint
    {
        private readonly IWriter _writer;

        public PrintService(IWriter writer)
        {
            _writer = writer;
        }

        public void PrintFilteredBooks(IEnumerable<Book> booksBy)
        {
            _writer.WriteLine(" ISBN, Author, Name, Author, Category, Language, DeadlineDate");

            foreach (var book in booksBy)
            {
                _writer.WriteLine($" {book.ISBN}, {book.Author}, {book.Name}, {book.Author}, {book.Category}, {book.Language}, {book.DeadlineDate} ");
            }
        }

    }
}
