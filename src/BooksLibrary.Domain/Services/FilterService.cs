using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Services
{
    public class FilterService : IFilter
    {
        public IEnumerable<Book> filterByAuthor(IEnumerable<Book> books, string value)
        {
            return books.Where(b => b.Author == value).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByBookName(IEnumerable<Book> books, string value)
        {
            return books.Where(b => b.Name == value).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByCategory(IEnumerable<Book> books, string value)
        {
            return books.Where(b => b.Category == value).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByISBN(IEnumerable<Book> books, string value)
        {
            return books.Where(b => b.ISBN == value).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByLanguage(IEnumerable<Book> books, string value)
        {
            return books.Where(b => b.Language == value).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByAvailableToTake(IEnumerable<Book> books)
        {
            return books.Where(b => b.ClientId == null).OrderBy(b => b.ISBN);
        }

        IEnumerable<Book> IFilter.filterByTakenBook(IEnumerable<Book> books)
        {
            return books.Where(b => b.Author != null).OrderBy(b => b.ISBN);
        }
    }
}
