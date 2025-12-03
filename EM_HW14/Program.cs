using System;
using System.Collections.Generic;
using System.Text;

namespace EM_HW14
{
    public abstract class CustomRandom
    {
        private static Random random = new Random();

        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
        public static int Next(int max)
        {
            return random.Next(max);
        }
    }

    public abstract class ListService
    {
        private static List<string> _list = new List<string>() // з мейна - ніяк, бо приватна, конструктор - ніяк, бо статік, отже хардкод
            { "COBAL", "ALGOL", "Fortrun", // просто додав деякі дані для наглядності
              "Lisp", "Swift", "GOlang", "B"
            };

        private static char[] uppers = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            };

        private static char[] lowers = new char[]
        {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        };

        private static char[] digits = new char[]
        {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        };

        private static char[] specials = new char[]
        {
                '-', '_', '=', '+', '|', '!', '@', '#', '$', '%',
                '^', '&', '*', ';', ':', '<', '>', '/', '?', '~',
        };

        // ----------------------------------------------------

        private static void CheckString(string str)
        {
            if (str.Trim().Length <= 0) { throw new Exception("Неможливо додати пустий рядок до списку."); }
        }
        private static void CheckIndex(byte index)
        {
            if (index >= _list.Count || index < 0) { throw new Exception($"Неможливо знайти елемент з введеним індексом({index})"); }
        }

        // ----------------------------------------------------

        public static void Add(string str) // не сподобалася назва "Create"
        {
            CheckString(str);
            _list.Add(str);
        }
        public static string ReadAt(byte index)
        {
            CheckIndex(index);
            return _list[index];
        }
        public static string[] ReadAll()
        {
            return _list.ToArray();
        }
        public static void ShowAll()
        {
            if (_list.Count == 0)
            {
                throw new Exception("Неможливо вивести пустий список.");
            }

            Console.WriteLine(string.Join(", ", _list));

        }
        public static void UpdateAt(byte index, string str)
        {
            CheckIndex(index);
            CheckString(str);
            _list[index] = str;
        }
        public static void DeleteAt(byte index)
        {
            CheckIndex(index);
            _list.RemoveAt(index);
        }

        // ----------------------------------------------------

        public static string GenerateString(int length, bool useLowers = true, bool useUppers = false, bool useDigits = false, bool useSpecials = false)
        {
            string str = "";
            List<char> range = new List<char>();

            if (useUppers) { range.AddRange(uppers); }
            if (useDigits) { range.AddRange(digits); }
            if (useSpecials) { range.AddRange(specials); }
            if (useLowers || range.Count == 0) { range.AddRange(lowers); }

            for (int i = 0; i < length; i++)
            {
                str += range[CustomRandom.Next(0, range.Count)];
            }

            return str;
        }
    }

    public abstract class DictionaryService
    {
        public static Dictionary<string, string> _dict = new Dictionary<string, string>() // з мейна - ніяк, бо приватна, конструктор - ніяк, бо статік, отже хардкор
            {
                { "Linus Torvalds", "+380991114242" },
                { "Tim Patterson", "+380992224242" },
                { "Richard Stallman", "+380993334242" },
                { "Ken Thompson", "+380993334242" },
            };

        // ----------------------------------------------------

        private static void CheckStrings(string key, string value)
        {
            if (key.Trim().Length <= 0 || value.Trim().Length <= 0) { throw new Exception("Неможливо додати пустий рядок до словнику."); }
        }
        private static void CheckKey(string key)
        {
            if (!(_dict.ContainsKey(key))) { throw new Exception($"Неможливо знайти елемент з введеним ключем(\"{ key }\")."); }
        }

        // ----------------------------------------------------

        public static void Add(string key, string value) // не сподобалася назва "Create"
        {
            CheckStrings(key, value);

            if (value.Length != 14 || !(value.Contains("+"))) { Console.WriteLine("Номер введено невірно або в неправильному форматі!"); }
            else { _dict.Add(key, value); }
        }
        public static void Delete(string key)
        {
            CheckKey(key);
            _dict.Remove(key);
        }
        public static void ShowAll() // на відміну від списків в мене не вийшло "позбутися" дженеріка, тому метод нічого не повертає і працює для райтлайну
        {
            if (_dict.Count == 0)
            {
                throw new Exception("Неможливо вивести пустий словник.");
            }

            foreach (KeyValuePair<string, string> item in _dict)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }

    internal class Program
    {
        static int IntegerInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
        static int IntegerInput(string message, string errorMessage)
        {
            Console.WriteLine(message);
            int integer = Convert.ToInt32(Console.ReadLine());
            if (integer <= 0) { throw new Exception(errorMessage); }
            return integer;
        }
        static string StringInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static string StringInput(string message, string errorMessage)
        {
            Console.WriteLine(message);
            string str = Convert.ToString(Console.ReadLine());
            if (str.Trim().Length == 0) { throw new Exception(errorMessage); }
            return str;
        }
        static void ShowError(string message)
        {
            Console.WriteLine("Помилка: " + message);
        }
        static void ShowSeparator()
        {
            Console.WriteLine("-=============================-");
        }
        static bool YesOrNo(string message)
        {
            ShowSeparator();
            byte attempts = 5; 
            for (int i = 0; i < attempts; i++)
            {
                Console.WriteLine(message + "(y/n)");
                char input = Convert.ToChar(Console.ReadLine());
                if (input == 'y') { return true; }
                else if(input == 'n') { return false; }
            }
            throw new Exception("Кількість спроб на відповідь вичерпано.");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            // 1+2.

            /*
            try
            {
                bool useLowers = true, useUppers = false, useDigits = false, useSpecials = false;

                int length = IntegerInput("Введіть довжину згенерованого слова: ", "Довжина слова не може бути недодатньою.");
                useLowers = YesOrNo("За замовчуванням використовуються тільки маленькі літери англійського алфавіту!\nВикористовувати маленькі літери англійського алфавіту під час генерації?");
                useUppers = YesOrNo("Використовувати великі літери англійського алфавіту під час генерації?");
                useDigits = YesOrNo("Використовувати цифри під час генерації?");
                useSpecials = YesOrNo("Використовувати спеціальні символи під час генерації?");

                ShowSeparator();
                int iterations = IntegerInput("Введіть бажану кількість згенерованих слів: ", "Кількість слів не може бути недодатньою.");
                ShowSeparator();

                for (int i = 0; i < iterations; i++)
                {
                    ListService.Add(ListService.GenerateString(length, useLowers, useUppers, useDigits, useSpecials));
                }
                Console.Write("Список разом з нещодавно згенерованими словами: ");
                ListService.ShowAll();
            }
            catch (FormatException)
            {
                ShowError("Ви не ввели дані або ввели дані неправильного типу.");
            }
            catch (IndexOutOfRangeException)
            {
                ShowError("Значення індексу вийшло за область допустимих значень.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            */

            // 3. 

            /*
            try
            {
                // просто функціонал створеного класу...
                DictionaryService.Add("Oleksandr Radionov", "+3801234567890");
                DictionaryService.ShowAll();
                ShowSeparator();
                DictionaryService.Delete("Oleksandr Radionov");
                DictionaryService.ShowAll();
            }
            catch (FormatException)
            {
                ShowError("Ви не ввели дані або ввели дані неправильного типу.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            */
        }
    }
}
