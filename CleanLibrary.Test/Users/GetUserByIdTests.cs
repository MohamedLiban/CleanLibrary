using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Users.Queries.GetUserById;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Test.Users
{
    public class GetUserByIdTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _handler = new GetUserByIdQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUser_WhenUserExists()
        {
            var userId = Guid.NewGuid();
            var user = new User(userId, "JohnDoe", "John", "Doe", "john@example.com", "hashedPassword");

            _mockRepository.Setup(repo => repo.GetUserByIdAsync(userId))
                .ReturnsAsync(user);

            var result = await _handler.Handle(new GetUserByIdQuery(userId), CancellationToken.None);

            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(userId);
            result.Data.FirstName.Should().Be("John");
            result.Data.LastName.Should().Be("Doe");
            result.Data.Email.Should().Be("john@example.com");
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenUserDoesNotExist()
        {
            _mockRepository.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((User)null);

            var result = await _handler.Handle(new GetUserByIdQuery(Guid.NewGuid()), CancellationToken.None);

            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().BeNull();
            result.ErrorMessage.Should().Be("User not found.");
        }
    }
}
