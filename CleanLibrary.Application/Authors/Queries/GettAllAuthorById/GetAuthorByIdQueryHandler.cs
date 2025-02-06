using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);

            if (author == null)
                return OperationResult<Author>.Failure("Author not found.");

            return OperationResult<Author>.Success(author);
        }
    }
}
