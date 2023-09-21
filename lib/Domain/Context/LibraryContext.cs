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

            modelBuilder.Entity<Copy>().HasData(
                new Copy { Id = 1, BookId = 2, Price = 15m, IsBorrowed = true },
                new Copy { Id = 2, BookId = 2, Price = 12m, IsBorrowed = true },
                new Copy { Id = 3, BookId = 2, Price = 9m, IsBorrowed = false },
                new Copy { Id = 4, BookId = 2, Price = 16m, IsBorrowed = false },
                new Copy { Id = 5, BookId = 2, Price = 6m, IsBorrowed = false });

            modelBuilder.Entity<BorrowTicket>().HasData(
                new BorrowTicket { Id = 1, BorrowingDate = new DateTime(2023, 9, 1), ClientName = "John John" },
                new BorrowTicket { Id = 2, BorrowingDate = new DateTime(2022, 9, 18), ClientName = "Jane Jane" });
        }
    }
}
