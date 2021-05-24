using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Interfaces
{
    public interface IPrint
    {
        void PrintFilteredBooks(IEnumerable<Book> booksBy);
        
    }
}
