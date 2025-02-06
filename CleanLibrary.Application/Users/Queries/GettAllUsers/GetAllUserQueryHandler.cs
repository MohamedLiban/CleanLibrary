using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<User>>>
    {
        private readonly IUserRepository _userRepository;

        
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public async Task<OperationResult<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
           
            var users = await _userRepository.GetAllUsersAsync();

            
            if (users == null || users.Count == 0)
                return OperationResult<List<User>>.Failure("No users found.");

            
            return OperationResult<List<User>>.Success(users);
        }
    }
}
