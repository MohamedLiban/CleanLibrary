using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Books.Commands.CreateBook;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using FluentValidation;

namespace CleanLibrary.Test.Books
{
    public class CreateBookTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly Mock<IValidator<Book>> _mockValidator;
        private readonly CreateBookCommandHandler _handler;

        public CreateBookTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockValidator = new Mock<IValidator<Book>>();
            _handler = new CreateBookCommandHandler(_mockRepository.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateBookSuccessfully()
        {
            var authorId = Guid.NewGuid();
            var bookId = Guid.NewGuid();
            var command = new CreateBookCommand("Harry Potter", authorId);
            var expectedBook = new Book(bookId, command.Title, command.AuthorId);

            _mockRepository.Setup(repo => repo.AddBookAsync(It.IsAny<Book>()))
                .ReturnsAsync((Book book) => book);

            _mockValidator.Setup(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBe(Guid.Empty);
            result.Should().Be(result);
        }
    }
}
