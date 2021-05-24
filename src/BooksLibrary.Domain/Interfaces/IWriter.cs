using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string input);
        string ReadLine(string text);
    }
}
