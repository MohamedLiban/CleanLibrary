using Microsoft.EntityFrameworkCore;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var author1 = new Author(Guid.NewGuid(), "J.K. Rowling");
            var author2 = new Author(Guid.NewGuid(), "J.R.R. Tolkien");

            modelBuilder.Entity<Author>().HasData(author1, author2);

            var book1 = new Book(Guid.NewGuid(), "Harry Potter and the Philosopher's Stone", author1.Id);
            var book2 = new Book(Guid.NewGuid(), "The Lord of the Rings", author2.Id);

            modelBuilder.Entity<Book>().HasData(book1, book2);
        }
    }
}
