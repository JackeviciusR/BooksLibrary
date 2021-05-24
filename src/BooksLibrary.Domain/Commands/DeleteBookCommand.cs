using BooksLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Commands
{
    public class DeleteBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;

        public DeleteBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Run()
        {
            var bookISBN = _writer.ReadLine("Enter ISBN of book");
            var books = _fileService.GetAll();
            var filteredBooks = books.Where(b => b.ISBN != bookISBN);
            _fileService.Overwrite(filteredBooks);
        }
    }
}
