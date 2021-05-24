using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Interfaces
{
    public interface IFileService
    {
        // AppendBook
        void SaveNewBook(Book book);

        IEnumerable<Book> GetAll(); // gal reikes

        void Overwrite(IEnumerable<Book> books);
    }
}
