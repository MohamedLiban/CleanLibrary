using MediatR;
using CleanLibrary.Domain.Models;
using System;

namespace CleanLibrary.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid BookId { get; }

        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
