using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using CleanLibrary.Application.Authors.Queries.GetAllAuthors;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Test.Authors
{
    public class GetAllAuthorsTests
    {
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;
        private readonly GetAllAuthorsQueryHandler _handler;

        public GetAllAuthorsTests()
        {
            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _handler = new GetAllAuthorsQueryHandler(_authorRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllAuthors_WhenAuthorsExist()
        {
            var authors = new List<Author>
            {
                new Author(Guid.NewGuid(), "J.K. Rowling"),
                new Author(Guid.NewGuid(), "J.R.R. Tolkien")
            };

            _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync())
                .ReturnsAsync(authors);

            var query = new GetAllAuthorsQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Name.Should().Be("J.K. Rowling");
            result.Data[1].Name.Should().Be("J.R.R. Tolkien");
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenNoAuthorsExist()
        {
            _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync())
                .ReturnsAsync(new List<Author>());

            var query = new GetAllAuthorsQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("No authors found.");
        }
    }
}
