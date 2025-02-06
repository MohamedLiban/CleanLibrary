using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using FluentValidation;
using CleanLibrary.Application.Books.Commands.UpdateBook;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Books
{
    public class UpdateBookTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly Mock<IValidator<Book>> _mockValidator;
        private readonly UpdateBookCommandHandler _handler;

        public UpdateBookTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockValidator = new Mock<IValidator<Book>>();
            _handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateBookSuccessfully()
        {
            var bookId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var existingBook = new Book(bookId, "Old Title", authorId);

            _mockRepository.Setup(repo => repo.GetBookByIdAsync(bookId))
                .ReturnsAsync(existingBook);

            _mockRepository.Setup(repo => repo.UpdateBookAsync(It.IsAny<Book>()))
                .ReturnsAsync(true);

            _mockValidator.Setup(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var command = new UpdateBookCommand(bookId, "Updated Title", authorId);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}
