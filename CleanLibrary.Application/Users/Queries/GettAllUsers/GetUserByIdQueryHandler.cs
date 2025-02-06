using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                return OperationResult<User>.Failure("User not found.");
            }

            return OperationResult<User>.Success(user);
        }
    }
}
