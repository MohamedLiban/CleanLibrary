using CleanLibrary.Domain.Models;
using System;
using System.Collections.Generic;

namespace CleanLibrary.Test.Setup
{
    public class FakeDatabase
    {
        public List<Author> Authors { get; set; } = new();
        public List<Book> Books { get; set; } = new();
        public List<User> Users { get; set; } = new();

        public FakeDatabase()
        {
            var author1 = new Author(Guid.NewGuid(), "J.K. Rowling");
            var author2 = new Author(Guid.NewGuid(), "J.R.R. Tolkien");

            Authors.Add(author1);
            Authors.Add(author2);

            Books.Add(new Book(Guid.NewGuid(), "Harry Potter and the Philosopher's Stone", author1.Id));
            Books.Add(new Book(Guid.NewGuid(), "The Lord of the Rings", author2.Id));

            Users.Add(new User(Guid.NewGuid(), "mohamedliban", "Mohamed", "Liban", "mohamed@example.com", "hashedpassword123"));
        }
    }
}
