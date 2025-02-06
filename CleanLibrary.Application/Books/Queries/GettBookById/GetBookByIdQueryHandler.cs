using System.Threading;
using System.Threading.Tasks;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using MediatR;

namespace CleanLibrary.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.BookId);
            return book;
        }
    }
}
