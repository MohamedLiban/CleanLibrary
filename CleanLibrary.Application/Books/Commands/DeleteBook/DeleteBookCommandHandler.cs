using CleanLibrary.Application.InterfacesRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanLibrary.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteBookAsync(request.BookId);
        }

    }
}
