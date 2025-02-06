using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.InterfacesRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(Guid bookId);
        Task<Book> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(Guid bookId);
    }
}
