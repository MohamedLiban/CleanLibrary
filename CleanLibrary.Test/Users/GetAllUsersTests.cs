using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Users.Queries.GetAllUsers;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Test.Users
{
    public class GetAllUsersTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly GetAllUsersQueryHandler _handler;

        public GetAllUsersTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUsers_WhenUsersExist()
        {
            var users = new List<User>
            {
                new User(Guid.NewGuid(), "john_doe", "John", "Doe", "john@example.com", "hashedpassword"),
                new User(Guid.NewGuid(), "jane_smith", "Jane", "Smith", "jane@example.com", "hashedpassword")
            };

            _mockRepository.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(users);

            var result = await _handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenNoUsersExist()
        {
            _mockRepository.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            var result = await _handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("No users found.");
        }
    }
}

