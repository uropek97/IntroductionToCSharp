using System;
using System.Diagnostics;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintDiagArr();
            //string[,] contacts = StorContacts();
            //string str = ReverseString();
            int input = 1111111;
            int i = 0;
            int e = 1_000_000;
            while (i!=e)
            {
                //input = int.Parse(Console.ReadLine());
                PrintSeaBattle();
                i++;
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Задание 1. Вывод элементов массива по диагонали.
        /// </summary>
        static void PrintDiagArr()
        {
            Console.WriteLine("Я понимаю задание двумя вариантами:\n" +
                "1) Вывести только диагональ элементов(т.е. array[0,0], array[1,1], array [2,2] и т.д. \n" +
                "2) Вывести все элементы по диагонали. Продемонстрирую оба варианта.");
            Console.Write("Выберите, какой из вариантов, вы хотите увидеть: ");
            int input = int.Parse(Console.ReadLine());
            Random rdm = new Random();
            int[,] arr = new int[5, 5];
            int[] diag = new int[5];
            int spaces = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rdm.Next(0, 10);
                    if (input == 2)
                    {
                        Console.WriteLine($"{arr[i, j].ToString().PadLeft(spaces)}");
                        spaces++;
                    }
                    diag[i] = arr[i, i];
                };
            }
            if (input == 1)
            {
                for (int i = 0; i < diag.Length; i++)
                {
                    Console.Write($"{diag[i]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Хотите ли увидеть массив в обычном виде? \n1 => да, \n2 => нет ");
            Console.Write("Ваш выбор: ");
            input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write($"{arr[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// Задание 2. Телефонный справочник
        /// </summary>
        /// <returns>Возвращает справочник в виде двумерного массива</returns>
        static string[,] StorContacts()
        {
            string[,] contacts =
            {
                {"Иванов", "Ivanov@gmail.com"},
                {"Петров", "Petrov@gmail.com"},
                {"Сидоров", "Sidorov@mail.ru"},
                {"Баженов", "BadComedian@gmail.com"},
                {"Батиков", "AlmostBadComedian@ya.ru"}
            };
            for (int i = 0; i < contacts.GetLength(0); i++)
            {
                for (int j = 0; j < contacts.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write($"Имя: {contacts[i, j]}. ");
                    }
                    else
                    {
                        Console.WriteLine($"Контактные данные: {contacts[i, j]};");
                    }
                }
            }
            return contacts;

        }
        /// <summary>
        /// Задание 3. Вывод введённой строки в обратном порядке.
        /// </summary>
        /// <returns>Возвращает перевёрнутую строку</returns>
        static string ReverseString()
        {
            Console.Write("Введите любую строку: ");
            string input = Console.ReadLine();
            char[] gap = input.ToCharArray();
            char[] outout = new char[gap.Length];
            for (int i = 0; i < gap.Length; i++)
            {
                outout[(outout.Length - 1) - i] = gap[i];
            }
            string reverseoutput = new string(outout);
            Console.WriteLine(reverseoutput);
            return reverseoutput;
        }
        /// <summary>
        /// Задание 4. Морской бой
        /// P.S. 
        /// </summary>
        static void PrintSeaBattle()
        {
            Random rdm = new Random();
            int random;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int commoncount = 0;
            char[,] seabattle = new char[10, 10];
            while (commoncount != 10)
            {
                for (int i = 0; i < seabattle.GetLength(0); i++)
                {
                    for (int j = 0; j < seabattle.GetLength(1); j++)
                    {
                        random = rdm.Next(1, 21);
                        switch (random)
                        {
                            case 1:
                                if (seabattle[i, j] == 'X')
                                {
                                    break;
                                }
                                if (count1 == 4)
                                {
                                    random = rdm.Next(2, 5);
                                    if (random == 2 && count2 < 3)
                                    {
                                        goto case 2;
                                    }
                                    else if (random == 3 && count3 < 2)
                                    {
                                        goto case 3;
                                    }
                                    else if (random == 4 && count4 < 1)
                                    {
                                        goto case 4;
                                    }
                                    else
                                    {
                                        goto default;
                                    }
                                }
                                if (i == (seabattle.GetLength(0) - 1) && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1) && j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == 0)
                                {
                                    if (seabattle[1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0)
                                {
                                    if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1))
                                {
                                    if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else
                                {
                                    if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                seabattle[i, j] = 'X';
                                count1++;
                                commoncount++;
                                break;
                            case 2:
                                if (seabattle[i, j] == 'X')
                                {
                                    break;
                                }
                                if (count2 == 3)
                                {
                                    random = rdm.Next(1, 4); // 3 и 4 будут 2 и 3 cases соответсвенно
                                    if (random == 1 && count1 < 4)
                                    {
                                        goto case 1;
                                    }
                                    else if (random == 2 && count3 < 2)
                                    {
                                        goto case 3;
                                    }
                                    else if (random == 3 && count4 < 1)
                                    {
                                        goto case 4;
                                    }
                                    else
                                    {
                                        goto default;
                                    }
                                }
                                if (i == (seabattle.GetLength(0) - 1) && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1) && j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == 0)
                                {
                                    if (seabattle[1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0)
                                {
                                    if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1))
                                {
                                    if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else
                                {
                                    if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                random = rdm.Next(0, 2);
                                if (random == 0)//по горизонтали 
                                {
                                    if (i == (seabattle.GetLength(0) - 1))
                                    {
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                    }
                                }
                                else
                                {
                                    if (j == (seabattle.GetLength(1) - 1))
                                    {
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                    }
                                }
                                count2++;
                                commoncount++;
                                break;
                            case 3:
                                if (seabattle[i, j] == 'X')
                                {
                                    break;
                                }
                                if (count3 == 2)
                                {
                                    random = rdm.Next(1, 4); // 3 = 4 case
                                    if (random == 1 && count1 < 4)
                                    {
                                        goto case 1;
                                    }
                                    else if (random == 2 && count2 < 3)
                                    {
                                        goto case 2;
                                    }
                                    else if (random == 3 && count4 < 1)
                                    {
                                        goto case 4;
                                    }
                                    else
                                    {
                                        goto default;
                                    }
                                }
                                if (i == (seabattle.GetLength(0) - 1) && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1) && j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == 0)
                                {
                                    if (seabattle[1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0)
                                {
                                    if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1))
                                {
                                    if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else
                                {
                                    if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                random = rdm.Next(0, 2);
                                if (random == 0)//по горизонтали 
                                {
                                    if ((i + 1) == (seabattle.GetLength(0) - 1))
                                    {
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                    }
                                    else if (i == (seabattle.GetLength(0) - 1))
                                    {
                                        seabattle[i - 2, j] = 'X';
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                        seabattle[i + 2, j] = 'X';
                                    }
                                }
                                else
                                {
                                    if ((j + 1) == (seabattle.GetLength(1)-1))
                                    {
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                    }
                                    else if (j == seabattle.GetLength(1)-1)
                                    {
                                        seabattle[i, j - 2] = 'X';
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                        seabattle[i, j + 2] = 'X';
                                    }
                                }
                                count3++;
                                commoncount++;
                                break;
                            case 4:
                                if (seabattle[i, j] == 'X')
                                {
                                    break;
                                }
                                if (count4 == 1)
                                {
                                    random = rdm.Next(1, 4);
                                    if (random == 1 && count1 < 4)
                                    {
                                        goto case 1;
                                    }
                                    else if (random == 2 && count2 < 3)
                                    {
                                        goto case 2;
                                    }
                                    else if (random == 3 && count3 < 2)
                                    {
                                        goto case 3;
                                    }
                                    else
                                    {
                                        goto default;
                                    }
                                }
                                if (i == (seabattle.GetLength(0) - 1) && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1) && j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == 0)
                                {
                                    if (seabattle[1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0 && j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == 0)
                                {
                                    if (seabattle[0, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[0, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (i == (seabattle.GetLength(0) - 1))
                                {
                                    if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == 0)
                                {
                                    if (seabattle[i - 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 0] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else if (j == (seabattle.GetLength(1) - 1))
                                {
                                    if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                else
                                {
                                    if (seabattle[i - 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i - 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j - 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                    else if (seabattle[i + 1, j + 1] == 'X')
                                    {
                                        seabattle[i, j] = 'O';
                                        break;
                                    }
                                }
                                random = rdm.Next(0, 2);
                                if (random == 0)//по горизонтали 
                                {
                                    if ((i + 2) == (seabattle.GetLength(0) - 1))
                                    {
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                        seabattle[i + 2, j] = 'X';
                                    }
                                    else if ((i + 1) == (seabattle.GetLength(0) - 1))
                                    {
                                        seabattle[i - 2, j] = 'X';
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                    }
                                    else if (i == seabattle.GetLength(0) - 1)
                                    {
                                        seabattle[i - 3, j] = 'X';
                                        seabattle[i - 2, j] = 'X';
                                        seabattle[i - 1, j] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i + 1, j] = 'X';
                                        seabattle[i + 2, j] = 'X';
                                        seabattle[i + 3, j] = 'X';
                                    }

                                }
                                else //по вертикали
                                {
                                    if ((j + 2) == (seabattle.GetLength(1) - 1))
                                    {
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                        seabattle[i, j + 2] = 'X';
                                    }
                                    else if ((j + 1) == (seabattle.GetLength(1) - 1))
                                    {
                                        seabattle[i, j - 2] = 'X';
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                    }
                                    else if (j == (seabattle.GetLength(1) - 1))
                                    {
                                        seabattle[i, j - 3] = 'X';
                                        seabattle[i, j - 2] = 'X';
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                    }
                                    else
                                    {
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                        seabattle[i, j + 2] = 'X';
                                        seabattle[i, j + 3] = 'X';
                                    }
                                }
                                commoncount++;
                                count4++;
                                break;
                            default:
                                if (seabattle[i, j] == 'X')
                                {
                                    break;
                                }
                                seabattle[i, j] = 'O';
                                break;
                        }

                    }

                }

            }

            for (int i = 0; i < seabattle.GetLength(0); i++)
            {
                for (int j = 0; j < seabattle.GetLength(1); j++)
                {
                    Console.Write($"{seabattle[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Однопалубных кораблей: {count1}");
            Console.WriteLine($"Двухпалубных кораблей: {count2}");
            Console.WriteLine($"Трёхпалубных кораблей: {count3}");
            Console.WriteLine($"Четырёхпалубных кораблей: {count4}");
            Console.WriteLine($"Всего кораблей: {commoncount}");
        }
    }
}
