using lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lib.Domain.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LibraryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new Author(1, "Author1"));
            
            modelBuilder.Entity<Book>().HasData(new Book(1, "Book1"));
        }
    }
}
