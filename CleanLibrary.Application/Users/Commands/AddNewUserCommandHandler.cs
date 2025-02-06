using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using BCrypt.Net;
using CleanLibrary.Application.Users.Commands.AddNewUser;

namespace CleanLibrary.Application.Users.Commands
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public AddNewUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User(Guid.NewGuid(), request.Username, request.FirstName, request.LastName, request.Email, request.Password);

            var createdUser = await _userRepository.AddUserAsync(newUser);

            return createdUser.Id; 
        }


    }
}
