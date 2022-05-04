using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now.ToShortDateString()}");

            Console.ReadLine();
        }
    }
}
