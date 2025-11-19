using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM_HW14
{
    internal class Program
    {
        // 1.
        // -----

        // 2.
        public static int CalculateTaxiJourney(int journey, int downtime)
        {
            int journeyRate = 10;
            int downtimeRate = 1;

            return journey*journeyRate + downtime*downtimeRate;
        }

        // 3.
        // -----

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Random random = new Random();

            // 1.


            /*
            try
            {
                double firstNumber = 0;
                char operation = ' ';
                double secondNumber = 0;
                double result = 0;


                Console.WriteLine("Додавання: +\nВіднімання: -\nМноження: *\nДілення: /\nКвадратний арифметичний корінь: √(Alt+251)\nПіднесення до степеня: ^\n");
                Console.WriteLine("Введіть перше число: ");
                firstNumber = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введіть операцію, яку потрібно провести з цими числами: ");
                operation = Convert.ToChar(Console.ReadLine());

                if (operation != '√')
                {
                    Console.WriteLine("Введіть друге число: ");
                    secondNumber = Convert.ToDouble(Console.ReadLine());
                }


                switch(operation)
                {
                    case '+':
                        result = firstNumber + secondNumber;
                        break;

                    case '-':
                        result = firstNumber - secondNumber;
                        break;

                    case '*':
                        result = firstNumber * secondNumber;
                        break;

                    case '/':
                        if (secondNumber == 0){ throw new Exception("Неможливо поділити на нуль."); }
                        result = firstNumber / secondNumber; 
                        break;

                    case '√':
                        result = Math.Sqrt(firstNumber);
                        break;

                    case '^':
                        if (secondNumber < 0) { throw new Exception("Не можна піднести число до від'ємного степеню."); } // до речі це неправда
                        result = Math.Pow(firstNumber, secondNumber);
                        break;

                    default:
                        throw new Exception("Обрано нерегламентовану операцію.");
                }
                if (operation != '√')
                {
                    Console.WriteLine($"\nРезультат розрахунків {firstNumber} {operation} {secondNumber} = {result}");
                }
                else
                {
                    Console.WriteLine($"Результат розрахунків\n √{firstNumber} = {result}");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Помилка: Ви ввели неправильні дані або дані не того типу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            */

            // 2.

            /*
            try
            {
                int journey = 0;
                int downtime = 0;
                int summary = 0;

                Console.WriteLine("Введіть відстань, на яку Вас повинно довести таксі у кілометрах: ");
                journey = Convert.ToInt32(Console.ReadLine());
                if (journey <= 0) { throw new Exception("Неможлива відстань поїздки."); }

                Console.WriteLine("Введіть час простою у хвилинах: ");
                downtime = Convert.ToInt32(Console.ReadLine());
                if (downtime < 0) { throw new Exception("Неможливий час простою."); }

                summary = CalculateTaxiJourney(journey, downtime);

                if (summary < 50)
                {
                    Console.WriteLine($"\nВаша поїздка коштує {summary} грн. Приміняється мінімальний тариф на поїздку(50 грн.)\n");
                    summary = 50;
                }

                Console.WriteLine("Остаточна вартість Вашої поїздки на таксі з вказаною відстаню поїздки та часом простою: " + summary + " грн.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: Ви ввели неправильні дані або дані не того типу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            */

            // 3.

            /*
            try
            {
                double consumption = 0;
                double cost = 0;

                Console.WriteLine("Введіть спожиту Вами електроенергію для розрахунку її вартості(у кВ/год.): ");
                consumption = Convert.ToDouble(Console.ReadLine());
                if (consumption <= 0) { throw new Exception("Введено неможливе значення спожитої електроенергії."); }

                if (consumption <= 100) { cost = consumption * 1.44; }
                else if (consumption <= 600) { cost = consumption * 1.68; }
                else { cost = consumption * 1.92; }

                Console.WriteLine($"Розрахована для Вас вартість спожитої Вами електроенергії({consumption} кВ/год.): {cost} грн.");

            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: Ви ввели неправильні дані або дані не того типу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            */

        }
    }
}
