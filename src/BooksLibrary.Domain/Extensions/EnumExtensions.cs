using BooksLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain.Extensions
{
    public static class EnumExtensions
    {
        // is taken from: https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp
        public static string ToStringAttributeDescription<TEnum>(this TEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
