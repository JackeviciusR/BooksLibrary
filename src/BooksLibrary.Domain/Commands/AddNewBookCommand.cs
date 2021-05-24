using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Commands
{
    public class AddNewBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;

        public AddNewBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Run()
        {
            var book = ToFillModelsValues();

            _fileService.SaveNewBook(book);
        }

        private Book ToFillModelsValues()
        {
            var book = new Book();
            PropertyInfo[] properties = typeof(Book).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "ClientId") break;
               
                var inputValue = _writer.ReadLine($"Enter book {property.Name}:").ToUpper();
                
                if (String.Concat(inputValue.Where(c => !Char.IsWhiteSpace(c))) == string.Empty)
                {
                    throw new ArgumentException("\nYou value is empty!!");
                }

                property.SetValue(book, inputValue);
            }

            return book;
        }

    }
}
