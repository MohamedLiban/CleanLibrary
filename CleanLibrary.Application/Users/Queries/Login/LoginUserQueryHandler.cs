using System.Threading;
using System.Threading.Tasks;
using CleanLibrary.Application.Users.Queries.Login;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using MediatR;
using BCrypt.Net;
using CleanLibrary.Application.Users.Login.Helpers;
using CleanLibrary.Application.Users.Login;


namespace CleanLibrary.Application.Users.Queries.Login 
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null || string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            return _tokenHelper.GenerateToken(user);
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
