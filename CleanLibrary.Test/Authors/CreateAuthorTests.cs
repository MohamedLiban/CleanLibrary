using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using FluentValidation;
using CleanLibrary.Application.Authors.Commands.CreateAuthor;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Authors
{
    public class CreateAuthorTests
    {
        private readonly Mock<IAuthorRepository> _mockRepository;
        private readonly Mock<IValidator<Author>> _mockValidator;
        private readonly CreateAuthorCommandHandler _handler;

        public CreateAuthorTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _mockValidator = new Mock<IValidator<Author>>();
            _handler = new CreateAuthorCommandHandler(_mockRepository.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateAuthorSuccessfully()
        {
            var command = new CreateAuthorCommand("George Orwell");

            _mockRepository.Setup(repo => repo.AddAuthorAsync(It.IsAny<Author>()))
                .ReturnsAsync((Author author) => author);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType<Author>();
            result.Id.Should().NotBe(Guid.Empty);
            result.Name.Should().Be("George Orwell");
        }
    }
}
