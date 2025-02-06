using CleanLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CleanLibrary.Infrastructure.Database
{
    public class FakeDatabase : DbContext
    {
        public FakeDatabase(DbContextOptions<FakeDatabase> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User > Users { get; set; } 
        
        public static void Seed(FakeDatabase context)
        {
            
            if (!context.Authors.Any())
            {
                var jkRowling = new Author(Guid.NewGuid(), "J.K. Rowling");
                var georgeOrwell = new Author(Guid.NewGuid(), "George Orwell");
                var jrrTolkien = new Author(Guid.NewGuid(), "J.R.R. Tolkien");

                context.Authors.AddRange(jkRowling, georgeOrwell, jrrTolkien);
                context.SaveChanges();
            }

            
            if (!context.Books.Any())
            {
                var jkRowling = context.Authors.First(a => a.Name == "J.K. Rowling");
                var georgeOrwell = context.Authors.First(a => a.Name == "George Orwell");
                var jrrTolkien = context.Authors.First(a => a.Name == "J.R.R. Tolkien");

                context.Books.AddRange(
                    new Book(Guid.NewGuid(), "Harry Potter and the Sorcerer's Stone", jkRowling.Id),
                    new Book(Guid.NewGuid(), "Harry Potter and the Chamber of Secrets", jkRowling.Id),
                    new Book(Guid.NewGuid(), "1984", georgeOrwell.Id),
                    new Book(Guid.NewGuid(), "Animal Farm", georgeOrwell.Id),
                    new Book(Guid.NewGuid(), "The Hobbit", jrrTolkien.Id),
                    new Book(Guid.NewGuid(), "The Lord of the Rings", jrrTolkien.Id)
                );

                context.SaveChanges();
            }
        }
    }
}
