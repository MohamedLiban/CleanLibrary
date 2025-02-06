using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CleanLibrary.Domain.Models;
using CleanLibrary.Application.InterfacesRepository;

namespace CleanLibrary.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books ?? new List<Book>();
        }
    }
}
