using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanLibrary.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _context;  

        public AuthorRepository(RealDatabase context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid authorId)
        {
            return await _context.Authors.FindAsync(authorId);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);
            if (existingAuthor == null) return false;

            existingAuthor.UpdateName(author.Name);  
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAuthorAsync(Guid authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
