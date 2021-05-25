using BooksLibrary.Domain.Commands;
using BooksLibrary.Domain.Factories;
using BooksLibrary.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksLibraryUnitTests.Factories
{
    
    public class CommandFactoryTests
    {
        [Fact]
        public void Build_CommandString_ReturnsCommand()
        {

            Mock <IWriter> writer = new();
            Mock <IFileService> fileService = new();
            Mock <IPrint> printService = new();
            Mock <IFilter> filterService = new();


            CommandFactory commandFactory = new(writer.Object, fileService.Object, printService.Object, filterService.Object);

            List<string> commandsNames = new()
            {
                "delete",
                "DeLete",
                "DELETE",
            };

            ICommand commandObject;

            foreach (var commandName in commandsNames)
            {
                commandObject = commandFactory.Build(commandName);
                commandObject.Should().BeOfType<DeleteBookCommand>();
            }

            Action commandAction = () => commandFactory.Build("");
            commandAction.Should().Throw<ArgumentException>()
                                  .WithMessage("Command is not recognized!");


        }

    }
}
