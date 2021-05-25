using BooksLibrary.Domain.Commands;
using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Factories
{
    public class CommandFactory
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private readonly IPrint _printService;
        private readonly IFilter _filterService;

        public CommandFactory(IWriter writer, IFileService fileService, IPrint printService, IFilter filterService)
        {
            _writer = writer;
            _fileService = fileService;
            _printService = printService;
            _filterService = filterService;
        }

        public ICommand Build(string input)
        {
            
            if (Enum.TryParse(input.ToUpper(), out CommandsEnums commandEnum))
            {
                switch (commandEnum)
                {
                    case CommandsEnums.ADD:
                        return new AddNewBookCommand(_writer, _fileService);
                    case CommandsEnums.DELETE:
                        return new DeleteBookCommand(_writer, _fileService);
                    case CommandsEnums.TAKE:
                        return new TakeBookCommand(_writer, _fileService);
                    case CommandsEnums.RETURN:
                        return new ReturnBookCommand(_writer, _fileService);
                    case CommandsEnums.LIST:
                        return new ListBookCommand(_writer, _fileService, _printService, _filterService);
                }
            }

            throw new ArgumentException("Command is not recognized!");
        }
    }
}
