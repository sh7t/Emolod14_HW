using System;
using System.Collections.Generic;
using System.Text;

namespace EM_HW14
{
    public static class ConsoleHelper
    {
        // funcs
        public static string StringInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }
        public static string StringInput(string message, string errorMessage)
        {
            string str = StringInput(message);
            if (str.Trim().Length == 0) { throw new Exception(errorMessage); }
            return str;
        }
        public static int IntegerInput(string message)
        {
            return Convert.ToInt32(StringInput(message));
        }
        public static void ShowError(string message)
        {
            Console.WriteLine("Error: " + message);
        }
        public static void ShowSeparator()
        {
            Console.WriteLine("-=============================-");
        }
    }
    public static class CustomRandom
    {
        // fields
        private static Random random = new Random();

        // funcs
        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
        public static int Next(int max)
        {
            return random.Next(max);
        }
    }

    public class Book
    {
        // fields
        private static int autoInc = 0;
        private readonly int id;
        private string title = "";
        private string author = "";
        private int year = 0;
        private bool isAvailable = false;

        // init
        public Book(string title, string author, int year, bool isAvailable)
        {
            this.id = autoInc++;

            setTitle(title);
            setAuthor(author);
            setYear(year);
            setIsAvailable(isAvailable);
        }

        // get-set'ters
        public int getId() => id;

        public string getTitle() => title;
        public void setTitle(string title)
        {
            if (title.Trim().Length < 2)
                throw new Exception("Expected longer title. Entered information is too short.");
            this.title = title.Trim();
        }

        public string getAuthor() => author;
        public void setAuthor(string author)
        {
            if (author.Trim().Length < 3)
                throw new Exception("Expected longer author's name. Entered information is too short.");
            this.author = author.Trim();
        }

        public int getYear() => year;
        public void setYear(int year)
        {
            if (year > DateTime.Now.Year)
                throw new Exception("Expected real year. Entered year \"" + year + "\" isn't real yet.");
            this.year = year;
        }

        public bool getIsAvailable() => isAvailable;
        public void setIsAvailable(bool isAvailable) { this.isAvailable = isAvailable; }
    }
    public static class LibraryService
    {
        // fields
        private static List<Book> library = new List<Book>();
        private static List<Book> userLibrary = new List<Book>();

        // funcs
        private static void CheckLibraryEmptiness(List<Book> lib)
        {
            if (lib.Count == 0)
                throw new Exception("Library is empty at the moment. Come back later!");
        }
        private static void CheckLibraryEmptiness(List<Book> lib, string errorMessage)
        {
            if (lib.Count == 0)
                throw new Exception(errorMessage);
        }
        private static void CheckIsIdInRange(List<Book> lib, int id)
        {
            if (library.Find(b => b.getId() == id) == null)
                throw new Exception("Entered ID is out of library's range!");
        }
        private static int GetIndexById(List<Book> lib, int id)
        {
            CheckLibraryEmptiness(lib);
            CheckIsIdInRange(lib, id);
            return lib.FindIndex(book => book.getId() == id);
        }
        private static int GetIndexById(List<Book> lib, int id, string errorMessage)
        {
            CheckLibraryEmptiness(lib, errorMessage);
            CheckIsIdInRange(lib, id);
            return lib.FindIndex(book => book.getId() == id);
        }

        public static void AddBook(Book book)
        {
            if ((library.Find(inLib => inLib.getTitle().ToLower() == book.getTitle().ToLower())) != null)
                throw new Exception($"{book.getTitle()} by {book.getAuthor()} is already in library!");
            library.Add(book);
            Console.WriteLine($"You successfully added {book.getTitle()} by {book.getAuthor()}!");
        }

        public static void ShowLibraryBooks()
        {
            CheckLibraryEmptiness(library);

            Console.WriteLine("ID   Book");
            foreach (Book book in library)
            {
                string availableOrNot = book.getIsAvailable() ? "Available" : "Unavailable";
                Console.WriteLine($"{book.getId()} | {book.getTitle()} by {book.getAuthor()} ({book.getYear()}) - {availableOrNot}");
            }
        }
        public static void ShowLibraryBooks(List<Book> lib, string errorMessage)
        {
            CheckLibraryEmptiness(lib, errorMessage);

            Console.WriteLine("ID   Book");
            foreach (Book book in lib)
            {
                Console.WriteLine($"{book.getId()} | {book.getTitle()} by {book.getAuthor()} ({book.getYear()})");
            }
        }

        public static void LendBook(int id)
        {
            int index = GetIndexById(library, id);

            if (!library[index].getIsAvailable())
                throw new Exception($"Book, which ID is {id}, is unavailable for now. Come back later!");

            userLibrary.Add(library[index]);
            library[index].setIsAvailable(false);
            Console.WriteLine($"You successfully lended {library[index].getTitle()} by {library[index].getAuthor()}!");
        }

        public static void ReturnBook(int id)
        {
            int index = GetIndexById(userLibrary, id, "Your library is empty at the moment. Come back later!");

            if (index == -1)
                throw new Exception($"There's no book in your library with ID {id}!");

            library[library.FindIndex(book => userLibrary[index].getId() == book.getId())].setIsAvailable(true);
            Console.WriteLine($"You successfully returned {userLibrary[index].getTitle()} by {userLibrary[index].getAuthor()}!");
            userLibrary.RemoveAt(index);
        }

        public static void RemoveBook(int id)
        {
            int index = GetIndexById(library, id);
            Console.WriteLine($"You successfully removed {library[index].getTitle()} by {library[index].getAuthor()}!");
            library.RemoveAt(index);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            // 1.
            // from 54 to 200

            // 2.
        }
    }
}
