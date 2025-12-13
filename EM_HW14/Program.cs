using System;
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
        public static int IntegerLineInput(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
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
    /*
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
    */
    /* public class Product
    {
        // fields
        private static int autoInc = 0;
        private readonly int id;
        private string name = "";
        private double price = 0;
        private uint quantity = 0; // experimental uint

        // init 
        public Product(string name, double price, uint quantity)
        {
            id = autoInc++;

            setName(name);
            setPrice(price);
            setQuantity(quantity);
        }

        // getset'ters
        public int getId() => id;

        public string getName() => name;
        public void setName(string name)
        {
            if (name.Trim().Length < 2)
                throw new Exception("Expected longer product name. Entered information is too short.");
            this.name = name.Trim();
        }
        public double getPrice() => price;
        public void setPrice(double price)
        {
            if (price < 0)
                throw new Exception("Expected real price. Entered information is impossible to be price.");
            this.price = Math.Round(price, 2);        
        }

        public uint getQuantity() => quantity;
        public void setQuantity(uint quantity) { this.quantity = quantity; }
    }
    public static class ProductsService
    {
        // fields
        private static List<Product> products = new List<Product>();

        // funcs
        private static void CheckProductsEmptiness()
        {
            if (products.Count == 0)
                throw new Exception("Products list is empty at the moment. Come back later!");
        }
        private static int GetIndexById(int id)
        {
            CheckProductsEmptiness();
            CheckIsIdInProducts(id);

            return products.FindIndex(product => product.getId() == id);
        }
        public static void CheckIsIdInProducts(int id)
        {
            if (products.Find(p => p.getId() == id) == null)
                throw new Exception("Entered ID is out of products list's range!");
        }
        public static void AddProduct(Product product)
        {
            if ((products.Find(prdct => prdct.getName().ToLower() == product.getName().ToLower())) != null)
                throw new Exception($"{product.getName()} is already in products list!");
            products.Add(product);
            Console.WriteLine($"You successfully added {product.getName()} for {product.getPrice()}!");
        }
        public static void ShowAllProducts()
        {
            CheckProductsEmptiness();

            Console.WriteLine("ID Product");
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.getId()} | {product.getName()} for {product.getPrice()} - {product.getQuantity()} pcs.");
            }
        }
        public static void UpdateProduct(int id, double price) { products[GetIndexById(id)].setPrice(price); }
        public static void UpdateProduct(int id, uint quantity) { products[GetIndexById(id)].setQuantity(quantity); }
        public static void UpdateProduct(int id, double price, uint quantity)
        {
            UpdateProduct(id, price);
            UpdateProduct(id, quantity);
        }

        public static void RemoveProduct(int id) { products.RemoveAt(GetIndexById(id)); }
        public static void FindProduct(string str)
        {
            CheckProductsEmptiness();
            List<Product> found = products.FindAll(product => product.getName().ToLower().Contains(str.ToLower()));
            if (found.Count == 0)
                throw new Exception($"Nothing found in products list by request {str}!");
            Console.WriteLine("ID   Found product");
            foreach (Product p in found)
            {
                Console.WriteLine($"{p.getId()} | {p.getName()} for {p.getPrice()} - {p.getQuantity()} pcs.");
            }
        }
        public static void BuyProduct(int id, double budget)
        {
            int index = GetIndexById(id);

            if (products[index].getQuantity() < Convert.ToUInt32(budget / products[index].getPrice()))
                throw new Exception("Not enough products to sell!");

            Console.WriteLine($"You successfully bought {products[index].getName()} for {products[index].getPrice()}/pcs. " +
                $"in the amount of {Convert.ToUInt32(budget / products[index].getPrice())}");
            Console.WriteLine($"Your rest: {budget - Convert.ToUInt32(budget / products[index].getPrice()) * products[index].getPrice()}");
            UpdateProduct(id, (products[index].getQuantity() - Convert.ToUInt32(budget / products[index].getPrice())));

        }


    }
    */ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            // куча ексепшенів обумовлена тим, що інтерфейси програм повинні бути зацикленим трай-кечами
            // (але я облінився їх робить)

            // 1.
            // from 54 to 200

            // 2.
            /*
            try
            {
                ProductsService.AddProduct(new Product("Laptop", 12999.00, 34));
                ProductsService.AddProduct(new Product("Smartphone", 8967.00, 78));
                ProductsService.AddProduct(new Product("Powerbank", 1270.00, 12));
                ConsoleHelper.ShowSeparator();

                ProductsService.ShowAllProducts();
                ConsoleHelper.ShowSeparator();

                int choosenId = ConsoleHelper.IntegerLineInput("Which product are you interested in? ID: ");
                ProductsService.CheckIsIdInProducts(choosenId);

                double budget = Convert.ToDouble(ConsoleHelper.IntegerLineInput("Your budget: "));
                if (budget <= 0)
                    throw new Exception("Expected real budget. Entered budget doesn't seem to be real!");

                ProductsService.BuyProduct(choosenId, budget);
                ConsoleHelper.ShowSeparator();
                ProductsService.ShowAllProducts();

            }
            catch (FormatException)
            {
                ConsoleHelper.ShowError("Incorrect input format!");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowError(ex.Message);
            }
            */
        }
    }
}
