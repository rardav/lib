using lib.Application.Repositories.Contracts;
using lib.Application.Services.Contracts;
using lib.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace lib.Application.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task PrintBooks()
        {
            var books = await _bookRepository.GetBooks();

            if (books.IsNullOrEmpty())
            {
                Console.WriteLine("No books for the moment.\n");

                return;
            }

            Console.WriteLine($"| {"Title",-20} | {"Author",-20} | {"ISBN",-20} |\n\n");
            foreach(var book in books)
            {
                Console.WriteLine($"| {book.Title,-20} | {book.Author,-20} | {book.Isbn,-20} |"); 
            }
        }

        public async Task PrintBookCopies(string title)
        {
            var book = await _bookRepository.GetBookWithCopies(title);

            if (book is null || book.Copies.IsNullOrEmpty())
            {
                Console.WriteLine("No such book or no copies of it for the moment.\n");

                return;
            }

            Console.WriteLine($"| {"Title",-20} | {"CopyId",-20} | {"Price",-20} | {"Available",-20} |\n\n");
            foreach (var copy in book.Copies)
            {
                Console.WriteLine($"| {book.Title,-20} | {copy.Id,-20} | {copy.Price,-20} | {(copy.IsBorrowed ? "No" : "Yes"), 20} |");
            }
        }

        public async Task LendBook(string title)
        {
            var book = await _bookRepository.GetBookWithCopies(title);

            if (book is null)
            {
                Console.WriteLine("No such book for the moment.\n");

                return;
            }

            var copyToBorrow = book.Copies.FirstOrDefault(copy => !copy.IsBorrowed);

            if (copyToBorrow is null)
            {
                Console.WriteLine("The book doesn't have any available copies for the moment.\n");

                return;
            }

            Console.Write("\nEnter client name: ");
            var clientName = Console.ReadLine();

            copyToBorrow.IsBorrowed = true;
            copyToBorrow.BorrowTickets.Add(new BorrowTicket
            {
                BorrowingDate = DateTime.Now,
                ClientName = clientName
            });

            await _bookRepository.UpdateBook(book);

            Console.WriteLine($"{book.Title} (copy id: {copyToBorrow.Id}) was just borrowed by {clientName} for {copyToBorrow.Price}RON");
        }

        public async Task CreateBook(string title, string author, string isbn, decimal price)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Isbn = isbn,
                Copies = new List<Copy>()
                {
                    new Copy
                    {
                        Price = price,
                        IsBorrowed = false
                    }
                }
            };

            await _bookRepository.InsertBook(book);
        }

        public async Task ReturnBook(string title)
        {
            var book = await _bookRepository.GetBookWithCopies(title);

            if (book is null || book.Copies.IsNullOrEmpty())
            {
                Console.WriteLine("No such book or no copies of it for the moment.\n");

                return;
            }

            Console.Write("\nEnter client name: ");
            var clientName = Console.ReadLine();

            var lentCopy = book.Copies
                .FirstOrDefault(copy => copy.IsBorrowed 
                    && copy.BorrowTickets.Select(ticket => ticket.ClientName).Contains(clientName));

            if (lentCopy is null )
            {
                Console.WriteLine($"No copy was borrowed by {clientName}\n");

                return;
            }
        }
    }
}
