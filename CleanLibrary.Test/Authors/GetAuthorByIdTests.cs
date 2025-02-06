using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Authors.Queries.GetAuthorById;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Test.Authors
{
    public class GetAuthorByIdTests
    {
        private readonly Mock<IAuthorRepository> _mockRepository;
        private readonly GetAuthorByIdQueryHandler _handler;
        private readonly Guid _authorId = Guid.NewGuid();

        public GetAuthorByIdTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _handler = new GetAuthorByIdQueryHandler(_mockRepository.Object);

            var author = new Author(_authorId, "J.K. Rowling");
            _mockRepository.Setup(repo => repo.GetAuthorByIdAsync(_authorId))
                .ReturnsAsync(author);
        }

        [Fact]
        public async Task Handle_ShouldReturnAuthor_WhenAuthorExists()
        {
            var result = await _handler.Handle(new GetAuthorByIdQuery(_authorId), CancellationToken.None);

            result.Should().NotBeNull();
            result.Data.Id.Should().Be(_authorId);
            result.Data.Name.Should().Be("J.K. Rowling");
        }
    }
}
