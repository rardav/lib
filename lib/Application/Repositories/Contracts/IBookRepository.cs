using lib.Domain.Entities;

namespace lib.Application.Repositories.Contracts
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetBooks();
    }
}
