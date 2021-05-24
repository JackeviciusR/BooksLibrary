using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Enums
{
    public enum CommandsEnums
    {
        [Description("Add new book")]
        ADD,
        [Description("Take book")]
        TAKE,
        [Description("Return book")]
        RETURN,
        [Description("Delete book")]
        DELETE,
        [Description("List all books")]
        LIST,


    }
}
