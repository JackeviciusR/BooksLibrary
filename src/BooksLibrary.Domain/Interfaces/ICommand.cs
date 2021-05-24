using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Interfaces
{
    public interface ICommand
    {
        public void Run();
    }
}
