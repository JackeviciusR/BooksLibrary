using BooksLibrary.Application;
using BooksLibrary.Application.Writers;
using BooksLibrary.Domain.Factories;
using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.ConsoleStarter
{
    public class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<BooksLibraryCLI>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .AddSingleton<IFileService, JsonFileService>()
                .AddSingleton<IPrint, PrintService>()
                .AddSingleton<IFilter, FilterService>()
                .AddSingleton<CommandFactory>()
                .BuildServiceProvider();
        }
    }
}
