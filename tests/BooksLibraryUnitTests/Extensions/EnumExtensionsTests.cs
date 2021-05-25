using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksLibraryUnitTests.Extensions
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void ToStringAttributeDescription_GivenString_ReturnsDescription()
        {
            CommandsEnums commandsEnums = new();
            
            var result = commandsEnums.ToStringAttributeDescription();

            result.Should().BeOfType<string>();
        }

    }
}
