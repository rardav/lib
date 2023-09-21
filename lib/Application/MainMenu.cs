namespace lib.Application
{
    public static class MainMenu
    {
        public static void StartApp()
        {
            ShowMainMenu();
        }

        private static void Divider()
        {
            Console.WriteLine("\n=============================================================================================\n");
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static string Read()
        {
            var answer = Console.ReadLine();

            Clear();

            return answer;
        }

        private static void ShowMainMenu()
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
                        //AddBook();
                        _currentAnswer = "0";
                        break;
                    case "2":
                        //ShowAllBooks();
                        _currentAnswer = "0";
                        break;
                    case "3":
                        //ShowBookCopies();
                        _currentAnswer = "0";
                        break;
                    case "4":
                        //LendBook();
                        _currentAnswer = "0";
                        break;
                    case "5":
                        //ReturnBook();
                        _currentAnswer = "0";
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
