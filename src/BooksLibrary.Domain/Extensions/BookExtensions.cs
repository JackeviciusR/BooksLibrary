using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Extensions
{
    public static class BookExtensions
    {
        
        public static Book UpdateBookCheckIn(this Book book, int clientId)
        {
            book.ClientId = clientId;
            book.TakenDate = DateTime.Now;
            book.DeadlineDate = DateTime.Now.AddMonths(2);

            return book;
        }

        public static Book UpdateBookCheckOut(this Book book, int clientId)
        {
            book.ClientId = null;
            book.TakenDate = null;
            book.DeadlineDate = null;

            return book;
        }


    }


}
