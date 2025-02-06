using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<OperationResult<Author>>
    {
        public Guid AuthorId { get; }

        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
