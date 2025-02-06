using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanLibrary.Test.Setup
{
    public class FakeRepositorySetup : IAuthorRepository, IBookRepository, IUserRepository
    {
        private readonly FakeDatabase _db;

        public FakeRepositorySetup()
        {
            _db = new FakeDatabase();
        }

       
        public Task<List<Author>> GetAllAuthorsAsync() => Task.FromResult(_db.Authors);
        public Task<Author?> GetAuthorByIdAsync(Guid authorId) => Task.FromResult(_db.Authors.FirstOrDefault(a => a.Id == authorId));
        public Task<Author> AddAuthorAsync(Author author) { _db.Authors.Add(author); return Task.FromResult(author); }
        public Task<bool> UpdateAuthorAsync(Author author) => Task.FromResult(true);
        public Task<bool> DeleteAuthorAsync(Guid authorId) { _db.Authors.RemoveAll(a => a.Id == authorId); return Task.FromResult(true); }

       
        public Task<List<Book>> GetAllBooksAsync() => Task.FromResult(_db.Books);
        public Task<Book?> GetBookByIdAsync(Guid bookId) => Task.FromResult(_db.Books.FirstOrDefault(b => b.Id == bookId));
        public Task<Book> AddBookAsync(Book book) { _db.Books.Add(book); return Task.FromResult(book); }
        public Task<bool> UpdateBookAsync(Book book) => Task.FromResult(true);
        public Task<bool> DeleteBookAsync(Guid bookId) { _db.Books.RemoveAll(b => b.Id == bookId); return Task.FromResult(true); }

       
        public Task<List<User>> GetAllUsersAsync() => Task.FromResult(_db.Users);
        public Task<User?> GetUserByIdAsync(Guid id) => Task.FromResult(_db.Users.FirstOrDefault(u => u.Id == id));
        public Task<User?> GetUserByEmailAsync(string email) => Task.FromResult(_db.Users.FirstOrDefault(u => u.Email == email));
        public Task<User> AddUserAsync(User user) { _db.Users.Add(user); return Task.FromResult(user); }
        public Task<bool> UpdateUserAsync(User user) => Task.FromResult(true);
        public Task<bool> DeleteUserAsync(Guid id) { _db.Users.RemoveAll(u => u.Id == id); return Task.FromResult(true); }
    }
}
