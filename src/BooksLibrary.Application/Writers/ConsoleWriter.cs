using BooksLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            System.Console.WriteLine(input);
        }

        public string ReadLine(string text)
        {
            WriteLine(text);
            return System.Console.ReadLine();
        }

    }
}
