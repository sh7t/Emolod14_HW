using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EM_HW14
{
    public abstract class CustomRandom
    {
        private static Random random = new Random();

        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }

    internal class Program
    {

        static int[] CreateRandomIntArray(int length, int min, int max)
        {
            int[] array = new int[length];
            
            for (int i = 0; i < array.Length;  i++)
            {
                array[i] = CustomRandom.Next(min, max);
            }

            return array;
        }
        
        static int[][] CreateRandomInt2DArray(int length, int min, int max)
        {
            int[][] array = new int[length][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = CreateRandomIntArray(length, min, max);
            }

            return array;
        }

        static int IntInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
        static string StrInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static void ShowError(string message)
        {
            Console.WriteLine("Помилка: " + message);
        }



        static void Main(string[] args)
        {
            

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Random random = new Random();



            // 1.

            /*
            try
            {
                const int LENGTH = 10, MIN = 10, MAX = 99;
                int inRangeCounter = 0, divisionCounter = 0;

                int[][] array = CreateRandomInt2DArray(LENGTH, MIN, MAX);

                int rangeMin = IntInput("Введіть мінімальму межу діапазону пошуку: ");
                int rangeMax = IntInput("Введіть максимальну межу діапазону пошуку: ");

                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (array[i][j] >= rangeMin && array[i][j] <= rangeMax) { inRangeCounter++; }
                        if (array[i][j] % 5 == 0) { divisionCounter++; }
                    }
                }


                Console.WriteLine($"Кількість елементів двовимірного масиву, які знаходяться у вказаному Вами діапазоні: {inRangeCounter}\nА також елементів, що кратні 5: {divisionCounter}");
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

            // 2.

            /*
            const int LENGTH = 100, MIN = 100, MAX = 900;

            int[] array = CreateRandomIntArray(LENGTH, MIN, MAX);
            Array.Sort(array);

            Console.WriteLine($"Друге найбільше число у масиві з 100 випадкових елементів це {array[array.Length - 2]}.");
            */

            // 3.

            /*
            try
            {
                string input = StrInput("Введіть речення: ").ToLower();
                if (input.Trim().Length == 0) { throw new Exception("Ви не ввели текст."); }

                Dictionary<char, int> dict = new Dictionary<char, int>();

                foreach (char c in input)
                {
                    if (dict.ContainsKey(c)) { dict[c]++; }
                    else { dict[c] = 1; }
                }

                foreach (var item in dict)
                {
                    Console.WriteLine($"\'{item.Key}\': {item.Value}");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            */

            // 4.

            const int LENGTH = 20, MIN = 10, MAX = 100;

            int[] array = CreateRandomIntArray(LENGTH, MIN, MAX);
            int daBiggestResult = 0;
            int daBestMiddleIndex = 0;

            for (int i = 1; i < 18; i++)
            {
                if (array[i - 1] + array[i] + array[i + 1] > daBiggestResult)
                {
                    daBestMiddleIndex = i;
                    daBiggestResult = array[i - 1] + array[i] + array[i + 1];
                }
            }

            Console.WriteLine($"[{daBestMiddleIndex-1}] + [{daBestMiddleIndex}] + [{daBestMiddleIndex+1}] = " +
                $"{array[daBestMiddleIndex - 1]} + {array[daBestMiddleIndex]} + {array[daBestMiddleIndex + 1]}");
            Console.WriteLine("Найбільша сума з підмасивів рівна " + daBiggestResult);

        }
    }
}
