using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Authors.Commands.UpdateAuthor;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using FluentValidation;

namespace CleanLibrary.Test.Authors
{
    public class UpdateAuthorTests
    {
        private readonly Mock<IAuthorRepository> _mockRepository;
        private readonly Mock<IValidator<Author>> _mockValidator;
        private readonly UpdateAuthorCommandHandler _handler;

        public UpdateAuthorTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _mockValidator = new Mock<IValidator<Author>>();
            _handler = new UpdateAuthorCommandHandler(_mockRepository.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateAuthorSuccessfully()
        {
            var authorId = Guid.NewGuid();
            var existingAuthor = new Author(authorId, "Original Name");

            _mockRepository.Setup(repo => repo.GetAuthorByIdAsync(authorId))
                .ReturnsAsync(existingAuthor);

            _mockRepository.Setup(repo => repo.UpdateAuthorAsync(It.IsAny<Author>()))
                .ReturnsAsync(true);

            _mockValidator.Setup(v => v.ValidateAsync(It.IsAny<Author>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var command = new UpdateAuthorCommand(authorId, "Updated Name");

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}
