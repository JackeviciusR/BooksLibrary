using BooksLibrary.Application;
using BooksLibrary.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BooksLibrary.ConsoleStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library start!");

            var serviceProvider = DependencyInjection.ConfigureServices();

            var booksLibraryCLI = serviceProvider.GetService<BooksLibraryCLI>();

            

            while (true)
            {
                booksLibraryCLI.PrintEnums<CommandsEnums>();
                booksLibraryCLI.RunCommands();
            }
        }
    }
}
