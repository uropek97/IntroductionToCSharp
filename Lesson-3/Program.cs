using System;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = -1;
            Console.WriteLine("Здравствуйте!");
            while (input != 0)
            {
                Console.WriteLine("1 => Задача 1. Вывод элементов массива по диагонали.");
                Console.WriteLine("2 => Задача 2. Телефонный справочник.");
                Console.WriteLine("3 => Задача 3. Вывод введённой строки в обратном порядке.");
                Console.WriteLine("4 => Задача 4. Морской бой.");
                Console.WriteLine("0 => Выход из программы.");
                Console.Write("Выберите номер задачи: ");
                int.TryParse(Console.ReadLine(), out input);
                if (input == 1)
                {
                    PrintDiagArr();
                }
                else if (input == 2)
                {
                    string[,] contacts = StorContacts();
                }
                else if (input == 3)
                {
                    string str = ReverseString();
                }
                else if (input == 4)
                {
                    Console.WriteLine("Решил эту задачу двумя ");
                    Console.WriteLine("1 => Способ 1.");
                    Console.WriteLine("2 => Способ 2.");
                    Console.WriteLine("0 => Выход из программы.");
                    Console.WriteLine("Любое другое число => возврат к выбору задачи.");
                    Console.Write("Выберите вариант: ");
                    int.TryParse(Console.ReadLine(), out input);
                    if (input == 1)
                    {
                        PrintSeaBattle();
                    }
                    else if (input == 2)
                    {
                        PrintSeaBattleV2();
                    }
                    else if (input == 0)
                    {
                        Console.WriteLine("Выход из программы...");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input == 0)
                {
                    Console.WriteLine("Выход из программы...");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine();
            }

            //Проверял на работоспособность методов - за миллион итерация ни в одном ни одной ошибки.
            //По поводу быстродействия: первая версия отработала заа 33 минуты, вторая за 30. Улучшенная версия немного быстрее(но полагаю это несущественно)
            //int count1 = 1_000_000;
            //int count = count1;
            //int check1 = 0;
            //int check = 0;
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //while (count1 != 0)
            //{
            //    check1 += PrintSeaBattleV2();
            //    Console.WriteLine("====================");
            //    count1--;
            //}
            //watch.Stop();
            //TimeSpan ts = watch.Elapsed;
            //Console.WriteLine(check1);
            //Console.WriteLine(ts);
            //watch.Reset();
            //watch.Start();
            //while (count != 0)
            //{
            //    check += PrintSeaBattle();
            //    Console.WriteLine("====================");
            //    count--;
            //}
            //watch.Stop();
            //ts = watch.Elapsed;
            //Console.WriteLine(check);
            //Console.WriteLine(ts);
            //Console.ReadLine();
        }
        /// <summary>
        /// Задание 1. Вывод элементов массива по диагонали.
        /// </summary>
        static void PrintDiagArr()
        {
            Console.WriteLine("Я понимаю задание двумя вариантами:\n" +
                "1 => Вывести только диагональ элементов(т.е. array[0,0], array[1,1], array [2,2] и т.д. \n" +
                "2 => Вывести все элементы по диагонали. Продемонстрирую оба варианта.");
            Console.Write("Выберите, какой из вариантов, вы хотите увидеть(0 => возврат к выбору задачи.): ");
            int.TryParse(Console.ReadLine(), out int input);
            if (input != 1 & input != 2)
            {
                return;
            }
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
        /// Первая версия, в коде чёрт ногу сломит. На наличие ошибок проверял, запуская цикл в миллион итераций.
        /// Вообще его нужно отсюда убрать, не проверяйте его(!) 
        /// Просто как демонстрация самостоятельной работы над ошибками. Ну и как-то не хочется убирать его, потрачено приличное количество времени :)
        /// </summary>
        static int PrintSeaBattle()
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
                                    if ((j + 1) == (seabattle.GetLength(1) - 1))
                                    {
                                        seabattle[i, j - 1] = 'X';
                                        seabattle[i, j] = 'X';
                                        seabattle[i, j + 1] = 'X';
                                    }
                                    else if (j == seabattle.GetLength(1) - 1)
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
            if (count1 == 4 && count2 == 3 && count3 == 2 && count4 == 1 && commoncount == 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Задание 4. Улучшенная версия. Хоть тоже из бесконечный проверок код состоит, но догадался размещать не весь корабль изначально,
        /// а только один конец, что сразу упростило задачу.
        /// </summary>
        static int PrintSeaBattleV2()
        {
            Random rdm = new Random();
            int direction; //направление по горизонтали(0)/вертикали(1)
            int line; //строки
            int column; // столбы
            int three = 0;//счётчик трёхбалубных
            int two = 0;//счётчик двухпалубных
            int one = 0;//счётчик однопалубных
            int count = 0;
            char[,] battleground = new char[10, 10];
            //Первым размещааем четырёхпалубный корабль
            direction = rdm.Next(2);
            if (direction == 0)//по горизонтали
            {
                line = rdm.Next(10);//если по горизонтали, то battleground[column+-, line]
                column = rdm.Next(7); // Определяем только один конец корабля. battleground[9, line] 9 - последняя клетка, за пределы не выйдет;
                battleground[column, line] = 'X';
                battleground[column + 1, line] = 'X';
                battleground[column + 2, line] = 'X';
                battleground[column + 3, line] = 'X';
            }
            else
            {
                column = rdm.Next(10);
                line = rdm.Next(7);
                battleground[column, line] = 'X';
                battleground[column, line + 1] = 'X';
                battleground[column, line + 2] = 'X';
                battleground[column, line + 3] = 'X';
            }
            while (three != 2)//размещаем трёхпалубные. нам нужны проверки, так как уже есть занятые клетки. как только выставляем 2 корабля, заканчивается цикл. 
            {
                direction = rdm.Next(2);
                if (direction == 0)
                {
                    line = rdm.Next(10);
                    column = rdm.Next(8);//индекс 7 последний(т.е. начало корабля максимум на 7 индексе, далее 8 и 9)
                    if (battleground[column, line] == 'X')
                    {
                        continue;
                    }
                    else if (column == 0 && line == 0) //Начало корабля в углу 0,0
                    {
                        if (battleground[0, 1] == 'X' || battleground[1, 1] == 'X' || battleground[1, 0] == 'X' || battleground[2, 0] == 'X' || battleground[2, 1] == 'X'
                            || battleground[3, 0] == 'X' || battleground[3, 1] == 'X')//не делаем проверку в точке 0.0 так как ранее уже она была проверена, аналогично для всех остальных
                        {
                            continue;
                        }
                        battleground[0, 0] = 'X';
                        battleground[1, 0] = 'X';
                        battleground[2, 0] = 'X';
                    }
                    else if (column == 7 && line == 0) //Начало корабля 7,0 (конец - угол 9,0)
                    {
                        if (battleground[6, 0] == 'X' || battleground[6, 1] == 'X' || battleground[7, 1] == 'X' || battleground[8, 0] == 'X' || battleground[8, 1] == 'X'
                            || battleground[9, 0] == 'X' || battleground[9, 1] == 'X')
                        {
                            continue;
                        }
                        battleground[7, 0] = 'X';
                        battleground[8, 0] = 'X';
                        battleground[9, 0] = 'X';
                    }
                    else if (column == 0 && line == 9) //Начало корабля 0,9
                    {
                        if (battleground[0, 8] == 'X' || battleground[1, 9] == 'X' || battleground[1, 8] == 'X' || battleground[2, 9] == 'X' || battleground[2, 8] == 'X'
                            || battleground[3, 9] == 'X' || battleground[3, 8] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 9] = 'X';
                        battleground[1, 9] = 'X';
                        battleground[2, 9] = 'X';
                    }
                    else if (column == 7 && line == 9) //Начало корабля 7,9
                    {
                        if (battleground[6, 9] == 'X' || battleground[6, 8] == 'X' || battleground[7, 8] == 'X' || battleground[8, 9] == 'X' || battleground[8, 8] == 'X'
                            || battleground[9, 9] == 'X' || battleground[9, 8] == 'X')
                        {
                            continue;
                        }
                        battleground[7, 9] = 'X';
                        battleground[8, 9] = 'X';
                        battleground[9, 9] = 'X';
                    }
                    else if (column == 0) //Корабль начинаеется в первом столбе, не в углу
                    {
                        if (battleground[0, line - 1] == 'X' || battleground[1, line - 1] == 'X' || battleground[2, line - 1] == 'X' || battleground[3, line - 1] == 'X'
                            || battleground[1, line] == 'X' || battleground[2, line] == 'X' || battleground[3, line] == 'X' || battleground[0, line + 1] == 'X'
                            || battleground[1, line + 1] == 'X' || battleground[2, line + 1] == 'X' || battleground[3, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[0, line] = 'X';
                        battleground[1, line] = 'X';
                        battleground[2, line] = 'X';
                    }
                    else if (line == 0) //Корабль в первой линии, не в углу
                    {
                        if (battleground[column - 1, 0] == 'X' || battleground[column - 1, 1] == 'X' || battleground[column, 1] == 'X' || battleground[column + 1, 0] == 'X'
                            || battleground[column + 1, 1] == 'X' || battleground[column + 2, 0] == 'X' || battleground[column + 2, 1] == 'X' || battleground[column + 3, 0] == 'X'
                            || battleground[column + 3, 1] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 0] = 'X';
                        battleground[column + 1, 0] = 'X';
                        battleground[column + 2, 0] = 'X';

                    }
                    else if (column == 7) //Корабль заканчивается в последнем столбе, не в углу
                    {
                        if (battleground[6, line - 1] == 'X' || battleground[7, line - 1] == 'X' || battleground[8, line - 1] == 'X' || battleground[9, line - 1] == 'X'
                            || battleground[6, line] == 'X' || battleground[8, line] == 'X' || battleground[9, line] == 'X' || battleground[6, line + 1] == 'X'
                            || battleground[7, line + 1] == 'X' || battleground[8, line + 1] == 'X' || battleground[9, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[7, line] = 'X';
                        battleground[8, line] = 'X';
                        battleground[9, line] = 'X';
                    }
                    else if (line == 9) //Корабль в последней линии, не в углу
                    {
                        if (battleground[column - 1, 8] == 'X' || battleground[column - 1, 9] == 'X' || battleground[column, 8] == 'X' || battleground[column + 1, 8] == 'X'
                            || battleground[column + 1, 9] == 'X' || battleground[column + 2, 8] == 'X' || battleground[column + 2, 9] == 'X' || battleground[column + 3, 8] == 'X'
                            || battleground[column + 3, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 9] = 'X';
                        battleground[column + 1, 9] = 'X';
                        battleground[column + 2, 9] = 'X';

                    }
                    else //Все углы учтены, все края тоже, далее проверки, если ни один из предыдущих случаев. 
                    {
                        if (battleground[column - 1, line - 1] == 'X' || battleground[column, line - 1] == 'X' || battleground[column + 1, line - 1] == 'X'
                            || battleground[column + 2, line - 1] == 'X' || battleground[column + 3, line - 1] == 'X' || battleground[column - 1, line] == 'X'
                            || battleground[column + 1, line] == 'X' || battleground[column + 2, line] == 'X' || battleground[column + 3, line] == 'X'
                            || battleground[column - 1, line + 1] == 'X' || battleground[column, line + 1] == 'X' || battleground[column + 1, line + 1] == 'X'
                            || battleground[column + 2, line + 1] == 'X' || battleground[column + 3, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[column, line] = 'X';
                        battleground[column + 1, line] = 'X';
                        battleground[column + 2, line] = 'X';
                    }
                    three++;
                }
                else //по вертикали
                {
                    line = rdm.Next(8);//индекс 7 - последний индекс начала корабля. 
                    column = rdm.Next(10);
                    if (battleground[column, line] == 'X')
                    {
                        continue;
                    }
                    else if (column == 0 && line == 0) //если начало в углу, координаты 0,0
                    {
                        if (battleground[1, 0] == 'X' || battleground[0, 1] == 'X' || battleground[1, 1] == 'X' || battleground[0, 2] == 'X' || battleground[1, 2] == 'X'
                            || battleground[0, 3] == 'X' || battleground[1, 3] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 0] = 'X';
                        battleground[0, 1] = 'X';
                        battleground[0, 2] = 'X';
                    }
                    else if (column == 0 && line == 7) //если начало в углу, координаты 0,7
                    {
                        if (battleground[0, 6] == 'X' || battleground[1, 6] == 'X' || battleground[1, 7] == 'X' || battleground[0, 8] == 'X' || battleground[1, 8] == 'X'
                            || battleground[0, 9] == 'X' || battleground[1, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 7] = 'X';
                        battleground[0, 8] = 'X';
                        battleground[0, 9] = 'X';
                    }
                    else if (column == 9 && line == 0) //если начало в углу, координаты 9,0
                    {
                        if (battleground[8, 0] == 'X' || battleground[8, 1] == 'X' || battleground[9, 1] == 'X' || battleground[8, 2] == 'X' || battleground[9, 2] == 'X'
                            || battleground[8, 3] == 'X' || battleground[9, 3] == 'X')
                        {
                            continue;
                        }
                        battleground[9, 0] = 'X';
                        battleground[9, 1] = 'X';
                        battleground[9, 2] = 'X';
                    }
                    else if (column == 9 && line == 7) //если начало в углу, координаты 9,7
                    {
                        if (battleground[8, 6] == 'X' || battleground[9, 6] == 'X' || battleground[8, 7] == 'X' || battleground[8, 8] == 'X' || battleground[9, 8] == 'X'
                            || battleground[8, 9] == 'X' || battleground[9, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[9, 7] = 'X';
                        battleground[9, 8] = 'X';
                        battleground[9, 9] = 'X';
                    }
                    else if (line == 0) //Корабль начинается в первой строке, не в углу
                    {
                        if (battleground[column - 1, 0] == 'X' || battleground[column - 1, 1] == 'X' || battleground[column - 1, 2] == 'X' || battleground[column - 1, 3] == 'X'
                            || battleground[column, 1] == 'X' || battleground[column, 2] == 'X' || battleground[column, 3] == 'X' || battleground[column + 1, 0] == 'X'
                            || battleground[column + 1, 1] == 'X' || battleground[column + 1, 2] == 'X' || battleground[column + 1, 3] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 0] = 'X';
                        battleground[column, 1] = 'X';
                        battleground[column, 2] = 'X';
                    }
                    else if (column == 0) //Корабль в первом столбе, не в углу
                    {
                        if (battleground[0, line - 1] == 'X' || battleground[1, line - 1] == 'X' || battleground[1, line] == 'X' || battleground[0, line + 1] == 'X'
                            || battleground[1, line + 1] == 'X' || battleground[0, line + 2] == 'X' || battleground[1, line + 2] == 'X' || battleground[0, line + 3] == 'X'
                            || battleground[1, line + 3] == 'X')
                        {
                            continue;
                        }
                        battleground[0, line] = 'X';
                        battleground[0, line + 1] = 'X';
                        battleground[0, line + 2] = 'X';
                    }
                    else if (line == 7) //Корабль заканчивается в последней строке, не в углу
                    {
                        if (battleground[column - 1, 6] == 'X' || battleground[column - 1, 7] == 'X' || battleground[column - 1, 8] == 'X' || battleground[column - 1, 9] == 'X'
                            || battleground[column, 6] == 'X' || battleground[column, 8] == 'X' || battleground[column, 9] == 'X' || battleground[column + 1, 6] == 'X'
                            || battleground[column + 1, 7] == 'X' || battleground[column + 1, 8] == 'X' || battleground[column + 1, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 7] = 'X';
                        battleground[column, 8] = 'X';
                        battleground[column, 9] = 'X';
                    }
                    else if (column == 9) //Корабль в последнем столбе, не в углу
                    {
                        if (battleground[8, line - 1] == 'X' || battleground[9, line - 1] == 'X' || battleground[8, line] == 'X' || battleground[8, line + 1] == 'X'
                            || battleground[9, line + 1] == 'X' || battleground[8, line + 2] == 'X' || battleground[9, line + 2] == 'X' || battleground[8, line + 3] == 'X'
                            || battleground[9, line + 3] == 'X')
                        {
                            continue;
                        }
                        battleground[9, line] = 'X';
                        battleground[9, line + 1] = 'X';
                        battleground[9, line + 2] = 'X';
                    }
                    else
                    {
                        if (battleground[column - 1, line - 1] == 'X' || battleground[column - 1, line] == 'X' || battleground[column - 1, line + 1] == 'X'
                            || battleground[column - 1, line + 2] == 'X' || battleground[column - 1, line + 3] == 'X' || battleground[column, line - 1] == 'X'
                            || battleground[column, line + 1] == 'X' || battleground[column, line + 2] == 'X' || battleground[column, line + 3] == 'X'
                            || battleground[column + 1, line - 1] == 'X' || battleground[column + 1, line] == 'X' || battleground[column + 1, line + 1] == 'X'
                            || battleground[column + 1, line + 2] == 'X' || battleground[column + 1, line + 3] == 'X')
                        {
                            continue;
                        }
                        battleground[column, line] = 'X';
                        battleground[column, line + 1] = 'X';
                        battleground[column, line + 2] = 'X';
                    }
                    three++;
                }
            }
            while (two != 3)
            {
                direction = rdm.Next(2);
                if (direction == 0)//по горизонтали 2-х палуб.
                {
                    line = rdm.Next(10);
                    column = rdm.Next(9);//индексы 8, 9
                    if (battleground[column, line] == 'X')
                    {
                        continue;
                    }
                    else if (column == 0 && line == 0) //если начало в углу, координаты 0,0
                    {
                        if (battleground[0, 1] == 'X' || battleground[1, 0] == 'X' || battleground[1, 1] == 'X' || battleground[2, 0] == 'X' || battleground[2, 1] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 0] = 'X';
                        battleground[1, 0] = 'X';
                    }
                    else if (column == 8 && line == 0) //если начало в углу, координаты 8,0
                    {
                        if (battleground[7, 0] == 'X' || battleground[7, 1] == 'X' || battleground[8, 1] == 'X' || battleground[9, 0] == 'X' || battleground[9, 1] == 'X')
                        {
                            continue;
                        }
                        battleground[8, 0] = 'X';
                        battleground[9, 0] = 'X';
                    }
                    else if (column == 0 && line == 9) //если начало в углу, координаты 0,9
                    {
                        if (battleground[0, 8] == 'X' || battleground[1, 9] == 'X' || battleground[1, 8] == 'X' || battleground[2, 9] == 'X' || battleground[2, 8] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 9] = 'X';
                        battleground[1, 9] = 'X';
                    }
                    else if (column == 8 && line == 9) //если начало в углу, координаты 8,9
                    {
                        if (battleground[7, 9] == 'X' || battleground[7, 8] == 'X' || battleground[8, 8] == 'X' || battleground[9, 9] == 'X' || battleground[9, 8] == 'X')
                        {
                            continue;
                        }
                        battleground[8, 9] = 'X';
                        battleground[9, 9] = 'X';
                    }
                    else if (column == 0) //Начало в 1 колонне, не в углу
                    {
                        if (battleground[0, line - 1] == 'X' || battleground[1, line - 1] == 'X' || battleground[2, line - 1] == 'X' || battleground[1, line] == 'X'
                            || battleground[2, line] == 'X' || battleground[0, line + 1] == 'X' || battleground[1, line + 1] == 'X' || battleground[2, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[0, line] = 'X';
                        battleground[1, line] = 'X';
                    }
                    else if (line == 0)//корабль в первой строке, не в углу
                    {
                        if (battleground[column - 1, 0] == 'X' || battleground[column - 1, 1] == 'X' || battleground[column, 1] == 'X' || battleground[column + 1, 0] == 'X'
                            || battleground[column + 1, 1] == 'X' || battleground[column + 2, 0] == 'X' || battleground[column + 2, 1] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 0] = 'X';
                        battleground[column + 1, 0] = 'X';
                    }
                    else if (column == 8) //конец корабля в последнем столбе, не в углу
                    {
                        if (battleground[7, line - 1] == 'X' || battleground[8, line - 1] == 'X' || battleground[9, line - 1] == 'X' || battleground[7, line] == 'X'
                            || battleground[9, line] == 'X' || battleground[7, line + 1] == 'X' || battleground[8, line + 1] == 'X' || battleground[9, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[8, line] = 'X';
                        battleground[9, line] = 'X';
                    }
                    else if (line == 9)//корабль в последней строке, не в углу
                    {
                        if (battleground[column - 1, 8] == 'X' || battleground[column - 1, 9] == 'X' || battleground[column, 8] == 'X' || battleground[column + 1, 8] == 'X'
                            || battleground[column + 1, 9] == 'X' || battleground[column + 2, 8] == 'X' || battleground[column + 2, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 9] = 'X';
                        battleground[column + 1, 9] = 'X';
                    }
                    else
                    {
                        if (battleground[column - 1, line - 1] == 'X' || battleground[column, line - 1] == 'X' || battleground[column + 1, line - 1] == 'X'
                            || battleground[column + 2, line - 1] == 'X' || battleground[column - 1, line] == 'X' || battleground[column + 1, line] == 'X'
                            || battleground[column + 2, line] == 'X' || battleground[column - 1, line + 1] == 'X' || battleground[column, line + 1] == 'X'
                            || battleground[column + 1, line + 1] == 'X' || battleground[column + 2, line + 1] == 'X')
                        {
                            continue;
                        }
                        battleground[column, line] = 'X';
                        battleground[column + 1, line] = 'X';
                    }
                    two++;
                }
                else //по вертикали
                {
                    line = rdm.Next(9);//индексы 8, 9
                    column = rdm.Next(10);
                    if (battleground[column, line] == 'X')
                    {
                        continue;
                    }
                    else if (column == 0 && line == 0) //если начало в углу, координаты 0,0
                    {
                        if (battleground[1, 0] == 'X' || battleground[0, 1] == 'X' || battleground[1, 1] == 'X' || battleground[0, 2] == 'X' || battleground[1, 2] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 0] = 'X';
                        battleground[0, 1] = 'X';
                    }
                    else if (column == 0 && line == 8) //если начало в углу, координаты 0,8
                    {
                        if (battleground[0, 7] == 'X' || battleground[1, 7] == 'X' || battleground[1, 8] == 'X' || battleground[0, 9] == 'X' || battleground[1, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[0, 8] = 'X';
                        battleground[0, 9] = 'X';
                    }
                    else if (column == 9 && line == 0) //если начало в углу, координаты 9,0
                    {
                        if (battleground[8, 0] == 'X' || battleground[8, 1] == 'X' || battleground[9, 1] == 'X' || battleground[8, 2] == 'X' || battleground[9, 2] == 'X')
                        {
                            continue;
                        }
                        battleground[9, 0] = 'X';
                        battleground[9, 1] = 'X';
                    }
                    else if (column == 9 && line == 8) //если начало в углу, координаты 9,8
                    {
                        if (battleground[8, 7] == 'X' || battleground[9, 7] == 'X' || battleground[8, 8] == 'X' || battleground[8, 9] == 'X' || battleground[9, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[9, 8] = 'X';
                        battleground[9, 9] = 'X';
                    }
                    else if (line == 0) //Начало корабля в первой линии, не в углу
                    {
                        if (battleground[column - 1, 0] == 'X' || battleground[column - 1, 1] == 'X' || battleground[column - 1, 2] == 'X' || battleground[column, 1] == 'X'
                            || battleground[column, 2] == 'X' || battleground[column + 1, 0] == 'X' || battleground[column + 1, 1] == 'X' || battleground[column + 1, 2] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 0] = 'X';
                        battleground[column, 1] = 'X';
                    }
                    else if (column == 0)//корабль в первом столбе, не в углу
                    {
                        if (battleground[0, line - 1] == 'X' || battleground[1, line - 1] == 'X' || battleground[1, line] == 'X' || battleground[0, line + 1] == 'X'
                            || battleground[1, line + 1] == 'X' || battleground[0, line + 2] == 'X' || battleground[1, line + 2] == 'X')
                        {
                            continue;
                        }
                        battleground[0, line] = 'X';
                        battleground[0, line + 1] = 'X';
                    }
                    else if (line == 8) ////Начало корабля в 9(8) линии, конец не в углу
                    {
                        if (battleground[column - 1, 7] == 'X' || battleground[column - 1, 8] == 'X' || battleground[column - 1, 9] == 'X'
                            || battleground[column, 7] == 'X' || battleground[column, 9] == 'X'
                            || battleground[column + 1, 7] == 'X' || battleground[column + 1, 8] == 'X' || battleground[column + 1, 9] == 'X')
                        {
                            continue;
                        }
                        battleground[column, 8] = 'X';
                        battleground[column, 9] = 'X';
                    }
                    else if (column == 9)//корабль в первом столбе, не в углу
                    {
                        if (battleground[8, line - 1] == 'X' || battleground[9, line - 1] == 'X' || battleground[8, line] == 'X' || battleground[8, line + 1] == 'X'
                            || battleground[9, line + 1] == 'X' || battleground[8, line + 2] == 'X' || battleground[9, line + 2] == 'X')
                        {
                            continue;
                        }
                        battleground[9, line] = 'X';
                        battleground[9, line + 1] = 'X';
                    }
                    else
                    {
                        if (battleground[column - 1, line - 1] == 'X' || battleground[column - 1, line] == 'X' || battleground[column - 1, line + 1] == 'X'
                            || battleground[column - 1, line + 2] == 'X' || battleground[column, line - 1] == 'X' || battleground[column, line + 1] == 'X'
                            || battleground[column, line + 2] == 'X' || battleground[column + 1, line - 1] == 'X' || battleground[column + 1, line] == 'X'
                            || battleground[column + 1, line + 1] == 'X' || battleground[column + 1, line + 2] == 'X')
                        {
                            continue;
                        }
                        battleground[column, line] = 'X';
                        battleground[column, line + 1] = 'X';
                    }
                    two++;
                }
            }
            while (one != 4)
            {
                column = rdm.Next(10);
                line = rdm.Next(10);
                if (battleground[column, line] == 'X')
                {
                    continue;
                }
                else if (column == 0 && line == 0) //если  в углу, координаты 0,0
                {
                    if (battleground[0, 1] == 'X' || battleground[1, 0] == 'X' || battleground[1, 1] == 'X')
                    {
                        continue;
                    }
                    battleground[0, 0] = 'X';
                }
                else if (column == 9 && line == 0) //если корабль в углу, координаты 9,0
                {
                    if (battleground[8, 0] == 'X' || battleground[8, 1] == 'X' || battleground[9, 1] == 'X')
                    {
                        continue;
                    }
                    battleground[9, 0] = 'X';
                }
                else if (column == 0 && line == 9) //если корабль в углу, координаты 0,9
                {
                    if (battleground[0, 8] == 'X' || battleground[1, 9] == 'X' || battleground[1, 8] == 'X')
                    {
                        continue;
                    }
                    battleground[0, 9] = 'X';
                }
                else if (column == 9 && line == 9) //если корабль в углу, координаты 9,9
                {
                    if (battleground[8, 8] == 'X' || battleground[8, 9] == 'X' || battleground[9, 8] == 'X')
                    {
                        continue;
                    }
                    battleground[9, 9] = 'X';
                }
                else if (column == 0)
                {
                    if (battleground[0, line - 1] == 'X' || battleground[1, line - 1] == 'X' || battleground[1, line] == 'X'
                        || battleground[0, line + 1] == 'X' || battleground[1, line + 1] == 'X')
                    {
                        continue;
                    }
                    battleground[0, line] = 'X';
                }
                else if (column == 9)
                {
                    if (battleground[8, line - 1] == 'X' || battleground[9, line - 1] == 'X' || battleground[8, line] == 'X'
                        || battleground[8, line + 1] == 'X' || battleground[9, line + 1] == 'X')
                    {
                        continue;
                    }
                    battleground[9, line] = 'X';
                }
                else if (line == 0)
                {
                    if (battleground[column - 1, 0] == 'X' || battleground[column - 1, 1] == 'X' || battleground[column, 1] == 'X'
                        || battleground[column + 1, 0] == 'X' || battleground[column + 1, 1] == 'X')
                    {
                        continue;
                    }
                    battleground[column, 0] = 'X';
                }
                else if (line == 9)
                {
                    if (battleground[column - 1, 9] == 'X' || battleground[column - 1, 8] == 'X' || battleground[column, 8] == 'X'
                        || battleground[column + 1, 9] == 'X' || battleground[column + 1, 8] == 'X')
                    {
                        continue;
                    }
                    battleground[column, 9] = 'X';
                }
                else
                {
                    if (battleground[column - 1, line - 1] == 'X' || battleground[column - 1, line] == 'X' || battleground[column - 1, line + 1] == 'X'
                        || battleground[column, line - 1] == 'X' || battleground[column, line + 1] == 'X' || battleground[column + 1, line - 1] == 'X'
                        || battleground[column + 1, line] == 'X' || battleground[column + 1, line + 1] == 'X')
                    {
                        continue;
                    }
                    battleground[column, line] = 'X';
                }
                one++;
            }
            for (int i = 0; i < battleground.GetLength(0); i++)
            {
                for (int j = 0; j < battleground.GetLength(1); j++)
                {
                    if (battleground[i, j] != 'X')
                    {
                        battleground[i, j] = '.';
                    }
                    else
                    {
                        count++;
                    }
                    Console.Write($"{battleground[i, j]} ");
                }
                Console.WriteLine();
            }
            if (three == 2 && two == 3 && one == 4 && count == 20)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}

