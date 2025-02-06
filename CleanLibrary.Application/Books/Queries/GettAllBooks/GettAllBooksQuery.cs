using System.Collections.Generic;
using CleanLibrary.Domain.Models;
using MediatR;

namespace CleanLibrary.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Book>> { }
}
