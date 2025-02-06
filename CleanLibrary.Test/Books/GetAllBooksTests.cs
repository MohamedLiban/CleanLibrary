using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Books.Queries.GetAllBooks;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Books
{
    public class GetAllBooksTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly GetAllBooksQueryHandler _handler;

        public GetAllBooksTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _handler = new GetAllBooksQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBooks_WhenBooksExist()
        {
            var books = new List<Book>
            {
                new Book(Guid.NewGuid(), "Harry Potter", Guid.NewGuid()),
                new Book(Guid.NewGuid(), "The Lord of the Rings", Guid.NewGuid())
            };

            _mockRepository.Setup(repo => repo.GetAllBooksAsync())
                .ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
    }
}
