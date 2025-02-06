using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using CleanLibrary.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RealDatabase _context;

        public BookRepository(RealDatabase context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(Guid bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookAsync(Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return false;

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
