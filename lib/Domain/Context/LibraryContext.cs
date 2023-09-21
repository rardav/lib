using lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lib.Domain.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<BorrowTicket> BorrowTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LibraryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "East of Eden", Author = "John Steinbeck", Isbn = "7463826281723" },
                new Book { Id = 2, Title = "The Shining", Author = "Stephen King", Isbn = "2735283638283" },
                new Book { Id = 3, Title = "The Green Mile", Author = "Stephen King", Isbn = "2735283245193" });
        }
    }
}
