using lib.Application.Repositories.Contracts;
using lib.Domain.Context;
using lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lib.Application.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _dbContext;

        public BookRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}
