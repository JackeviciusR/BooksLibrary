using BooksLibrary.Domain.Extensions;
using BooksLibrary.Domain.Factories;
using BooksLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application
{
    public class BooksLibraryCLI
    {
        private readonly IWriter _writer;
        private readonly CommandFactory _commandFactory;

        public BooksLibraryCLI(IWriter writer, CommandFactory commandFactory)
        {
            _writer = writer;
            _commandFactory = commandFactory;
        }

        public void PrintEnums<TEnum>()
        {
            _writer.WriteLine(Environment.NewLine + "Commands:");

            var commands = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (var command in commands)
            {
                _writer.WriteLine($"{command } : {command.ToStringAttributeDescription()}");
            }

            _writer.WriteLine(Environment.NewLine);
        }


        public void RunCommands()
        {
            try
            {
                var commandString = _writer.ReadLine("Please enter your command:").ToUpper();

                var command = _commandFactory.Build(commandString);

                command.Run();
            }
            catch (ArgumentException ex)
            {
                _writer.WriteLine(ex.Message);
            }

        }
    }
}
