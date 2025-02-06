using MediatR;

namespace CleanLibrary.Application.Users.Login
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Email { get; }
        public string Password { get; }

        public LoginUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
