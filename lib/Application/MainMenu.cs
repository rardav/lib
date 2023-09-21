using lib.Application.Services.Contracts;

namespace lib.Application
{
    public class MainMenu
    {
        private IBookService _bookService { get; set; }

        public MainMenu(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void StartApp()
        {
            ShowMainMenu();
        }

        private void Divider()
        {
            Console.WriteLine("\n=============================================================================================\n");
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void WaitForInputAndClear()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            Clear();

        }

        private string Read()
        {
            var answer = Console.ReadLine();

            Clear();

            return answer;
        }

        private async Task ShowMainMenu()
        {
            string _currentAnswer = "0";
            var menuValues = new string[] { "1", "2", "3" , "4", "5"};
            while (!menuValues.Contains(_currentAnswer))
            {
                Console.WriteLine("Welcome to Lib!");
                Divider();

                Console.WriteLine("Choose a number:" +
                    "\n\n1. Add new book" +
                    "\n2. Show all books" +
                    "\n3. Show available copies of a book" +
                    "\n4. Lend a book" +
                    "\n5. Return a book" +
                    "\n6. Exit" +
                    "\n");

                Console.Write("Your answer: ");
                _currentAnswer = Read();

                switch (_currentAnswer)
                {
                    case "1":
                        await AddBook();
                        _currentAnswer = "0";
                        WaitForInputAndClear();
                        break;
                    case "2":
                        await _bookService.PrintBooks();
                        _currentAnswer = "0";
                        WaitForInputAndClear();
                        break;
                    case "3":
                        await ShowBookCopies();
                        _currentAnswer = "0";
                        WaitForInputAndClear();
                        break;
                    case "4":
                        await LendBook();
                        _currentAnswer = "0";
                        WaitForInputAndClear();
                        break;
                    case "5":
                        await ReturnBook();
                        WaitForInputAndClear();
                        _currentAnswer = "0";
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private async Task ReturnBook()
        {
            Console.Write("Enter a book title: ");
            var title = Console.ReadLine();

            await _bookService.ReturnBook(title);
        }

        private async Task LendBook()
        {
            Console.Write("Enter a book title: ");
            var title = Console.ReadLine();

            await _bookService.LendBook(title);
        }

        private async Task AddBook()
        {
            Console.WriteLine("Add book info: ");

            Console.Write("Enter book title: ");
            var title = Console.ReadLine();

            Console.Write("\nEnter book author: ");
            var author = Console.ReadLine();

            Console.Write("\nEnter book isbn: ");
            var isbn = Console.ReadLine();

            decimal price;
            while (true)
            {
                Console.Write("Enter copy price: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out price))
                {
                    break;
                }
            }

            await _bookService.CreateBook(title, author, isbn, price);

            Console.Write("\nBook created successfully!\n\n");
        }

        private async Task ShowBookCopies()
        {
            Console.Write("Enter a book title: ");
            var title = Console.ReadLine();
            Clear();

            await _bookService.PrintBookCopies(title);
        }

    }
}
