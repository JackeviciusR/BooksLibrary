using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Extensions;
using BooksLibrary.Domain.Factories;
using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using BooksLibrary.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Commands
{
    public class ListBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private readonly IPrint _printService;
        private readonly IFilter _filterService;

        private IEnumerable<Book> books;

        public ListBookCommand(IWriter writer, IFileService fileService, IPrint printService, IFilter filterService)
        {
            _writer = writer;
            _fileService = fileService;
            _printService = printService;
            _filterService = filterService;
        }

        public void Run()
        {
            books = _fileService.GetAll();


            _writer.WriteLine(Environment.NewLine + "Filter Commands:");

            var commands = Enum.GetValues(typeof(FilterByEnums)).Cast<FilterByEnums>();

            foreach (var command in commands)
            {
                _writer.WriteLine($"{command } : {command.ToStringAttributeDescription()}");
            }

            _writer.WriteLine(Environment.NewLine);


            var filterBy = _writer.ReadLine($"Filter by:").ToUpper();
            
            if (String.Concat(filterBy.Where(c => !Char.IsWhiteSpace(c))) == string.Empty)
            {
                throw new ArgumentException("\nYou value is empty!!");
            }

            var filterValue = "";
            if (!Equals(filterBy, "AVAIL") && !Equals(filterBy, "TAK") )
            {
                filterValue = _writer.ReadLine($"Enter filtered value:");
            }

            var filtratedBooks = FilterBy(filterBy, books, filterValue);
            _printService.PrintFilteredBooks(filtratedBooks);

        }



        public IEnumerable<Book> FilterBy(string filterByCommand, IEnumerable<Book> books, string value)
        {
            //return new FilterByDelegates(_writer, _fileService);

            if (Enum.TryParse(filterByCommand, out FilterByEnums filterByEnum))
            {
                switch (filterByEnum)
                {
                    case FilterByEnums.AUTH:
                        return _filterService.filterByAuthor(books, value);
                    case FilterByEnums.CAT:
                        return _filterService.filterByCategory(books, value);
                    case FilterByEnums.LANG:
                        return _filterService.filterByLanguage(books, value);
                    case FilterByEnums.ISBN:
                        return _filterService.filterByISBN(books, value);
                    case FilterByEnums.NAME:
                        return _filterService.filterByBookName(books, value);
                    case FilterByEnums.TAK:
                        return _filterService.filterByTakenBook(books);
                    case FilterByEnums.AVAIL:
                        return _filterService.filterByAvailableToTake(books);
                }

            }

            throw new ArgumentException("Command is not recognized!");

        }


    }
}
