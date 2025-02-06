using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Authors.Commands.DeleteAuthor;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Authors
{
    public class DeleteAuthorTests
    {
        private readonly Mock<IAuthorRepository> _mockRepository;
        private readonly DeleteAuthorCommandHandler _handler;

        public DeleteAuthorTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _handler = new DeleteAuthorCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_Should_Delete_Author_When_Found()
        {
            var authorId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetAuthorByIdAsync(authorId))
                .ReturnsAsync(new Author(authorId, "J.K. Rowling"));  

            _mockRepository.Setup(repo => repo.DeleteAuthorAsync(authorId))
                .ReturnsAsync(true);  

            var command = new DeleteAuthorCommand(authorId);
            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();  
        }

        [Fact]
        public async Task Handle_Should_Return_False_When_Author_Not_Found()
        {
            var authorId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetAuthorByIdAsync(authorId))
                .ReturnsAsync((Author)null); 

            var command = new DeleteAuthorCommand(authorId);
            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeFalse();  
        }
    }
}
