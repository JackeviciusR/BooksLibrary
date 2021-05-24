using BooksLibrary.Domain.Interfaces;
using BooksLibrary.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Services
{
    public class JsonFileService : IFileService
    {
        private readonly string _dataUrl = AppDomain.CurrentDomain.BaseDirectory + "BookData.json";

        public IEnumerable<Book> GetAll()
        {
            List<Book> books = new();

            var lines = File.ReadAllLines(_dataUrl);

            foreach (var line in lines)
            {
                var book = JsonConvert.DeserializeObject<Book>(line);
                books.Add(book);
            }

            return books;
        }

        public void Overwrite(IEnumerable<Book> books)
        {
            File.WriteAllText(_dataUrl, "");

            foreach (var book in books)
            {
                SaveNewBook(book);
            }
        }

        public void SaveNewBook(Book book)
        {
            var jsonString = JsonConvert.SerializeObject(book);
            File.AppendAllText(_dataUrl, jsonString + Environment.NewLine);
        }
    }
}
