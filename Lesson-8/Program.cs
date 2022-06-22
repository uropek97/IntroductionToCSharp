using System;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Properties.Settings.Default.UserName = String.Empty;
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.Write("Введите имя пользователя:");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.Write("Возраст: ");
                try
                {
                    Properties.Settings.Default.UserAge = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Properties.Settings.Default.UserAge = 0;
                }
                Properties.Settings.Default.Save();
                Console.Write("Род деятельности: ");
                Properties.Settings.Default.UserJob = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.UserName;
            string greeting = Properties.Settings.Default.Greeting;
            int age = Properties.Settings.Default.UserAge;
            string userAge = (age % 10 == 0 || age %10==5 || age % 10 == 6 || age % 10 == 7 
                || age % 10 == 8 || age % 10 == 9) ? $"{age} лет" : age % 10 == 1 
                ? $"{age} год" : $"{age} года"; // 20/25-29 лет, 21 год, 22-24 года)
            string userJob = Properties.Settings.Default.UserJob;
            Console.WriteLine($"{greeting}, {userName}!({userAge}, {userJob})");

            Console.ReadLine();
        }
    }
}
