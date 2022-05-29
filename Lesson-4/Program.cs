using System;
using System.Threading;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!");

            int input = -1;
            while (input != 0)
            {
                Console.WriteLine("1 => Задание 1. Конкатенация строк.");
                Console.WriteLine("2 => Задание 2. Вычисление суммы чисел в строке.");
                Console.WriteLine("3 => Задание 3. Вывод времени года на экран.");
                Console.WriteLine("4 => Задание 4. Вычисления числа Фибоначчи.");
                Console.WriteLine("0 => Выход из программы.");
                Console.Write("Введите номер задачи: ");
                int.TryParse(Console.ReadLine(), out input);
                string haiglight = "================================================";
                Console.WriteLine(haiglight);
                if (input == 1)
                {
                    string name = "Игорь"; string surname = "Чебота"; string patron = "Александрович";
                    Console.WriteLine(GetFullName(name, surname, patron));
                    name = "Анна"; surname = "Ерешкова"; patron = "Витальевна";
                    Console.WriteLine(GetFullName(name, surname, patron));
                    name = "Константин"; surname = "Тимченко"; patron = "Яковлевич";
                    Console.WriteLine(GetFullName(name, surname, patron));
                    Console.WriteLine(GetFullName(out string firstName, out string lastName, out string patronymic));
                    Console.WriteLine(haiglight);
                }
                else if (input == 2)
                {
                    Sum(out string entry);
                    Console.WriteLine(haiglight);
                }
                else if (input == 3)
                {
                    Console.Write("Введите номер месяца: ");
                    int month;
                    do
                    {
                        int.TryParse(Console.ReadLine(), out int month1);
                        if (month1 < 1 || month1 > 12)
                        {
                            Console.WriteLine("Ошибка: Введите число от 1 до 12");
                            Thread.Sleep(1500);
                            Console.Write("Введите номер месяца: ");
                            continue;
                        }
                        else
                        {
                            month = month1;
                            break;
                        }
                    } while (true);
                    seasons season = GetSeason(month);
                    PrintSeason(season);
                    Console.WriteLine(haiglight);
                }
                else if (input == 4)
                {
                    Console.WriteLine("Задача решена двумя способами.");
                    Console.WriteLine("1 => Рекурсивно.");
                    Console.WriteLine("2 => С помощью цикла без рекурсии");
                    do
                    {
                        Console.Write("Способ номер: ");
                        int.TryParse(Console.ReadLine(), out input);
                        if (input == 1)
                        {
                            Console.Write("Введите число: ");
                            int.TryParse(Console.ReadLine(), out int fibonacci);
                            Console.WriteLine($"{fibonacci}-е число в последовательности Фибоначи: {Fibonacci(fibonacci)}");
                            break;
                        }
                        else if (input == 2)
                        {
                            Console.Write("Введите число: ");
                            int.TryParse(Console.ReadLine(), out int fibonacci);
                            Console.WriteLine($"{fibonacci}-е число в последовательности Фибоначи: {FibonacciWithoutRecursion(fibonacci)}");
                            break;
                        }
                        else
                        {
                            Console.Write("Ошибка. Введите число 1 или 2. ");
                            continue;
                        }
                    }
                    while (true);
                    Console.WriteLine(haiglight);
                }
                else if (input == 0)
                {
                    Console.WriteLine("Завершение программы...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Для дальнейшей работы программы нужно ввести число от 0 до 4.");
                    Thread.Sleep(2000);
                    Console.WriteLine(haiglight);
                }
            }
        }
        /// <summary>
        /// Задание 1. Получение целой строки ФИО из отдельных имени, фамилии, отчества
        /// /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns>Возвращает ФИО.</returns>
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
        /// <summary>
        /// Задание 1. Пользовательский поочерёдный ввод ФИО и получение целой строки ФИО.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns>Возвращает ФИО.</returns>
        static string GetFullName(out string firstName, out string lastName, out string patronymic)
        {
            Console.Write("Введите ваше имя: ");
            firstName = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Введите ваше отчество: ");
            patronymic = Console.ReadLine();
            string fullName = $"{lastName} {firstName} {patronymic}";
            return fullName;
        }
        /// <summary>
        /// Задание 2. Вычисление суммы чисел в строке.
        /// </summary>
        /// <param name="input">Пользовательский ввод строки</param>
        /// <returns>Возвращает сумму чисел в строке</returns>
        static int Sum(out string input)
        {
            Console.WriteLine("Введите числа, разделяя из пробелом.");
            input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += int.Parse(numbers[i]);
            }
            Console.WriteLine($"Сумма введённых чисел: {result}");

            return result;
        }
        /// <summary>
        /// Задание 3. Получение экземпляра seasons
        /// </summary>
        /// <param name="month">Номер месяца</param>
        /// <returns>возвращает экземпляр seasons</returns>
        static seasons GetSeason(int month)
        {
            if (month == 1 || month == 2 || month == 12)
            {
                return seasons.Winter;
            }
            else if (month == 3 || month == 4 || month == 5)
            {
                return seasons.Spring;
            }
            else if (month == 6 || month == 7 || month == 8)
            {
                return seasons.Summer;
            }
            else
            {
                return seasons.Autumn;
            }
        }
        /// <summary>
        /// Задание 3. Вывод времени года на экран.
        /// </summary>
        /// <param name="season"></param>
        static void PrintSeason(seasons season)
        {
            if (season == 0) //Здесь доступно, в обоих частях здесь якобы тип seasons
            {
                Console.WriteLine("Зима");
            }
            else if (season == (seasons)1)//Здесь недоступно сравнение с числом
            {
                Console.WriteLine("Весна");
            }
            else if (season == (seasons)2)
            {
                Console.WriteLine("Лето");
            }
            else
            {
                Console.WriteLine("Осень");
            }

        }
        /// <summary>
        /// Перечисление сезонов.
        /// </summary>
        enum seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        /// <summary>
        /// Задание 4. Вычисление числа Фибоначчи.
        /// </summary>
        /// <param name="fibonacci">Номер числа в последовательности</param>
        /// <returns>Возвращает число Фибоначчи</returns>
        static int Fibonacci(int fibonacci)
        {
            if (fibonacci == 0)
            {
                return 0;
            }
            else if (fibonacci == 1 || fibonacci == 2)
            {
                return 1;
            }
            fibonacci = Fibonacci(fibonacci - 1) + Fibonacci(fibonacci - 2);
            return fibonacci;
        }
        /// <summary>
        /// Задание 4. Вычисление числа Фибоначчи без рекурсии. На больших значениях работает гораздо быстрее. 
        /// </summary>
        /// <param name="fibonacci">Номер числа в последовательности</param>
        /// <returns>Возвращает число Фибоначчи</returns>
        static int FibonacciWithoutRecursion(int fibonacci)
        {
            {
                if (fibonacci == 0)
                {
                    return 0;
                }
                else if (fibonacci == 1 || fibonacci == 2)
                {
                    return 1;
                }
            }
            //первые 3 числа последовательности
            int fib1 = 0;
            int fib2 = 1;
            int fib3 = 1;
            for (int i = 1; i < fibonacci; i++)
            {
                fib3 = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib3;
            }
            return fib3;
        }
    }
}