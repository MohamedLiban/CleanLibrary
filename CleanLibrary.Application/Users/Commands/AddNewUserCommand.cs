using MediatR;

namespace CleanLibrary.Application.Users.Commands.AddNewUser
{
    public class AddNewUserCommand : IRequest<Guid>
    {
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public AddNewUserCommand(string username, string firstName, string lastName, string email, string password)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
