using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _5zadacha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите числа: ");
            string inputList = Console.ReadLine();

            string[] elements = inputList.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> numbers = new List<double>();

            for (int i = 0; i < elements.Length; i++)
            {
                if (!double.TryParse(elements[i], out double userNumber))
                {
                    Console.WriteLine("Ваш код содержит недопустимые значения!");
                    break;
                }

                numbers.Add(NumberСonversion(elements[i]));

                if (elements.Length == i + 1)
                {
                    string outputOne = "\n[" + string.Join(", ", elements) + "]";
                    Console.WriteLine(outputOne);

                    string outputTwo = "[" + string.Join(", ", numbers) + "]";
                    Console.WriteLine(outputTwo);
                }
            }
        }

        public static double NumberСonversion(string el)
        {
            double result = 0;
            if (int.TryParse(el, out int elInt) && el[0] != '-')
            {
                result = 1;
                for (int i = 1; i <= elInt; i++)
                    result *= i;
            }
            else if (int.TryParse(el, out int elIntNegative) && el[0] == '-')
            {
                result = elIntNegative;
            }
            else if (double.TryParse(el, out double elDouble))
            {
                double resultik = Math.Abs(elDouble - Math.Truncate(elDouble));
                result = Math.Round(resultik, 2) * 100;
            }
            return result;
        }
    }
}