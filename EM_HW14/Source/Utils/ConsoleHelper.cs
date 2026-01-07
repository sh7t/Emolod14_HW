using System;
using System.Text;

namespace EM_HW14.Source.Utils
{
    public static class ConsoleHelper
    {
        public static readonly string currency = "$";
        // funcs
        public static void ChangeEncodingToUTF8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
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
}
