using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Interfaces
{
    public interface IFilter
    {
        IEnumerable<Book> filterByAuthor(IEnumerable<Book> books, string value);

        IEnumerable<Book> filterByCategory(IEnumerable<Book> books, string value);

        IEnumerable<Book> filterByLanguage(IEnumerable<Book> books, string value);

        IEnumerable<Book> filterByISBN(IEnumerable<Book> books, string value);


        IEnumerable<Book> filterByBookName(IEnumerable<Book> books, string value);

        IEnumerable<Book> filterByTakenBook(IEnumerable<Book> books);

        IEnumerable<Book> filterByAvailableToTake(IEnumerable<Book> books);
    }
}
