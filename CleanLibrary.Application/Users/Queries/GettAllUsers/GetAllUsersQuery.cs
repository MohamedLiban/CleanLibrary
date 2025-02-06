using MediatR;
using CleanLibrary.Application.Common;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Users.Queries.GetAllUsers;
using CleanLibrary.Application.InterfacesRepository;


namespace CleanLibrary.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<OperationResult<List<User>>>
    {
    }
}
