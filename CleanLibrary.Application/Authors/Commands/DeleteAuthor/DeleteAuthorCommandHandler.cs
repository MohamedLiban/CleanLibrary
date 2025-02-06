using CleanLibrary.Application.InterfacesRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanLibrary.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetAuthorByIdAsync(request.AuthorId);
            if (author == null)
                return false; 

            var deleted = await _repository.DeleteAuthorAsync(request.AuthorId);
            return deleted;
        }

    }
}
