using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchAvrTemp();

            Console.ReadLine();
        }
        static void SearchAvrTemp()
        {
            Console.WriteLine("Введите минимальную температуру за сутки:");
            double min = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальную температуру за сутки:");
            double max = double.Parse(Console.ReadLine());

            double average = (min + max) / 2;
            Console.WriteLine($"Среднесуточная температура: {average}");
        }
    }
}
