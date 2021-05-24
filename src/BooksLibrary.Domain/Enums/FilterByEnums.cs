using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Enums
{
    public enum FilterByEnums
    {
        [Description("By Author")]
        AUTH,
        [Description("By Catagory")]
        CAT,
        [Description("By Language")]
        LANG,
        [Description("By ISBN")]
        ISBN,
        [Description("By Book Name")]
        NAME,
        [Description("By Taken Books")]
        TAK,
        [Description("By Available Books")]
        AVAIL,
    }
}
