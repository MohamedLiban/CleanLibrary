using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.InterfacesRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(Guid authorId);
        Task<Author> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(Guid authorId);
    }
}
