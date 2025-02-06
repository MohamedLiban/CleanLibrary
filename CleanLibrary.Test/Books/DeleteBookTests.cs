using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
using CleanLibrary.Application.Books.Commands.DeleteBook;
using CleanLibrary.Application.InterfacesRepository;

namespace CleanLibrary.Test.Books
{
    public class DeleteBookTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly DeleteBookCommandHandler _handler;

        public DeleteBookTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _handler = new DeleteBookCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteBook_WhenBookExists()
        {
            var bookId = Guid.NewGuid();

            _mockRepository.Setup(repo => repo.DeleteBookAsync(bookId))
                .ReturnsAsync(true);

            var result = await _handler.Handle(new DeleteBookCommand(bookId), CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}
