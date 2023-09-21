namespace lib.Application.Services.Contracts
{
    public interface IBookService
    {
        Task PrintBooks();
        Task PrintBookCopies(string title);
        Task CreateBook(string title, string author, string isbn, decimal price);
        Task LendBook(string title);
        Task ReturnBook(string title);

    }
}
