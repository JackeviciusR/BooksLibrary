using AutoFixture;
using BooksLibrary.Domain.Extensions;
using BooksLibrary.Domain.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksLibraryUnitTests.Extensions
{
    public class BookExtensionsTests
    {
        [Fact]
        public void UpdateBookCheckIn_GivenBookAndClientId_ReturnsUpdatedBook()
        {
            int clientId = 1111;

            var autoBook = new Fixture();
            var book = autoBook.Build<Book>()
                               .Without(b => b.ClientId)
                               .Without(b => b.TakenDate)
                               .Without(b => b.TakenDate)
                               .Create();

            var updatedBook = book.UpdateBookCheckIn(clientId);

            updatedBook.ClientId.Should().Be(1111);
            updatedBook.TakenDate.Should().BeCloseTo(DateTime.Now, 1000);
            updatedBook.DeadlineDate.Should().BeCloseTo(DateTime.Now.AddMonths(2), 1000);
        }

        [Fact]
        public void UpdateBookCheckIn_UpdateBookCheckOut_ReturnsResetBook()
        {
            int clientId = 1111;

            var autoBook = new Fixture();
            var book = autoBook.Build<Book>()
                               .With(b => b.DeadlineDate, DateTime.Now.AddMonths(2))
                               .Create();

            var resetedBook = book.UpdateBookCheckOut(clientId);

            resetedBook.ClientId.Should().Be(null);
            resetedBook.TakenDate.Should().Be(null);
            resetedBook.DeadlineDate.Should().Be(null);
        }

    }
}
