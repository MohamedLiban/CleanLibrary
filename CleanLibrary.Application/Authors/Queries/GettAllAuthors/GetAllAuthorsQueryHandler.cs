using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<Author>>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();

            if (authors == null || authors.Count == 0)
                return OperationResult<List<Author>>.Failure("No authors found.");

            return OperationResult<List<Author>>.Success(authors);
        }
    }
}
