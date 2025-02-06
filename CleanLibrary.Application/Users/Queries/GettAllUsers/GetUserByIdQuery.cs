using MediatR;
using CleanLibrary.Application.Common;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<OperationResult<User>>
    {
        public Guid UserId { get; set; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
