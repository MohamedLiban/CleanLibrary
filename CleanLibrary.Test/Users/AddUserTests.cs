using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Users.Commands.AddNewUser;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Test.Users
{
    public class AddUserTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly AddNewUserCommandHandler _handler;

        public AddUserTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _handler = new AddNewUserCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnNewUserId_WhenUserIsAdded()
        {
            var command = new AddNewUserCommand("JohnDoe", "John", "Doe", "john@example.com", "password123");

            var newUserId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
                .ReturnsAsync(new User(newUserId, "JohnDoe", "John", "Doe", "john@example.com", "hashedPassword123"));

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBe(Guid.Empty);
        }
    }
}
