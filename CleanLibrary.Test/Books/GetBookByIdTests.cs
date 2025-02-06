using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Books.Queries.GetBookById;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Books
{
    public class GetBookByIdTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly GetBookByIdQueryHandler _handler;

        public GetBookByIdTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _handler = new GetBookByIdQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBook_WhenBookExists()
        {
            var bookId = Guid.NewGuid();
            var book = new Book(bookId, "Harry Potter", Guid.NewGuid());

            _mockRepository.Setup(repo => repo.GetBookByIdAsync(bookId))
                .ReturnsAsync(book);

            var result = await _handler.Handle(new GetBookByIdQuery(bookId), CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(bookId);
            result.Title.Should().Be("Harry Potter");
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenBookDoesNotExist()
        {
            var bookId = Guid.NewGuid();

            _mockRepository.Setup(repo => repo.GetBookByIdAsync(bookId))
                .ReturnsAsync((Book)null);

            var result = await _handler.Handle(new GetBookByIdQuery(bookId), CancellationToken.None);

            result.Should().BeNull();
        }
    }
}
