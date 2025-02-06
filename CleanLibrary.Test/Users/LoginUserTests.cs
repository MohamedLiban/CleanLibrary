using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using CleanLibrary.Application.Users.Queries.Login;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Users.Login.Helpers;
using BCrypt.Net;
using CleanLibrary.Application.Users.Login;

namespace CleanLibrary.Test.Users
{
    public class LoginUserTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<ITokenHelper> _mockTokenHelper;
        private readonly LoginUserQueryHandler _handler;

        public LoginUserTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _mockTokenHelper = new Mock<ITokenHelper>();
            _handler = new LoginUserQueryHandler(_mockRepository.Object, _mockTokenHelper.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnToken_WhenCredentialsAreValid()
        {
            var email = "user@example.com";
            var password = "password123";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User(Guid.NewGuid(), "JohnDoe", "John", "Doe", email, hashedPassword);
            _mockRepository.Setup(repo => repo.GetUserByEmailAsync(email)).ReturnsAsync(user);
            _mockTokenHelper.Setup(token => token.GenerateToken(user)).Returns("valid-token");

            var result = await _handler.Handle(new LoginUserQuery(email, password), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().Be("valid-token");
        }
    }
}
