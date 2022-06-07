using System;
using System.IO;
using System.Threading;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string highlight = "=======================================";
            Console.WriteLine("Здравствуйте!");
            while (true)
            {
                Console.WriteLine("Выберите задачу: ");
                Console.WriteLine("1 => Задача 1. Ввод текста с клавиатуры и запись его в файл.");
                Console.WriteLine("2 => Задача 2. Дописывание текущего времени в файл.");
                Console.WriteLine("3 => Задача 3. Запись чисел в бинарный файл");
                Console.WriteLine("4 => Задача 4. Деревья каталогов");
                Console.WriteLine("5 => Задача 5. ToDo-list");
                Console.WriteLine("0 => Выход из программы.");
                int.TryParse(Console.ReadLine(), out int input);
                if (input == 0)
                {
                    Console.WriteLine("Выход из программы...");
                    Console.ReadKey(true);
                    return;
                }
                else if (input == 1)
                {
                    WorkWithFile.AddText();
                    Console.WriteLine(highlight);
                }
                else if (input == 2)
                {
                    WorkWithFile.AddTime();
                    Console.WriteLine(highlight);
                }
                else if (input == 3)
                {
                    WorkWithFile.WriteBinaryFile();
                    Console.WriteLine(highlight);
                }
                else if (input == 4)
                {
                    Console.WriteLine("Распечатать дерево каталогов и файлов. \n С рекусрией:");
                    Thread.Sleep(1000);
                    Console.Write("Введите путь каталога(без @): ");
                    //string name = "@" + Console.ReadLine();
                    string name = @"D:\C#\Homeworks\IntroductionToCSharp\IntroductionToCSharp\Lesson-5";
                    WorkWithDirectories.PrintDirRec(new DirectoryInfo(name), "", true, "Directories-Rec.txt");
                    Thread.Sleep(5000);
                    Console.WriteLine("Без рекусрии(до конца добить не смог):");
                    Thread.Sleep(1000);
                    WorkWithDirectories.PrintDir(new DirectoryInfo(name), "Directories.txt");
                }
                else if (input == 5)
                {
                    string name = "tasks.bin";
                    if (File.Exists(name))
                    {
                        Console.WriteLine("Список задач десериализованный из бинарного файла: ");
                        ToDo[] list = ToDo.DeserializeBinTasks(name);
                        ToDo.PrintTasks(list);
                    }
                    else
                    {
                        Console.WriteLine("Список задач, который будет сериализован в бинарный файл: ");
                        ToDo[] list = ToDo.WriteAllTasks();
                        ToDo.PrintTasks(list);
                        ToDo.SerializeBinTasks(name, list);
                    }
                    Console.WriteLine(highlight);
                    Thread.Sleep(1500);
                    name = "tasks.json";
                    if (File.Exists(name))
                    {
                        Console.WriteLine("Список задач десериализованный из файла формата json: ");
                        ToDo[] list2 = ToDo.DeserializeJsonTasks(name);
                        ToDo.PrintTasks(list2);
                    }
                    else
                    {
                        Console.WriteLine("Список задач, который будет сериализован в файл формата json: ");
                        ToDo[] list2 = ToDo.WriteAllTasksUpdate();
                        ToDo.PrintTasks(list2);
                        ToDo.SerializeJsonTasks(name, list2);
                    }
                    Console.WriteLine(highlight);
                    Thread.Sleep(1500);
                    name = "tasks.xml";
                    if (File.Exists(name))
                    {
                        Console.WriteLine("Список задач десериализованный из файла формата xml: ");
                        ToDo[] list3 = ToDo.DeserializeXmlTasks(name);
                        ToDo.PrintTasks(list3);
                    }
                    else
                    {
                        Console.WriteLine("Список задач, который будет сериализован в файл формата xml: ");
                        ToDo[] list3 = ToDo.WriteTasks();
                        ToDo.PrintTasks(list3);
                        ToDo.SerializeXmlTasks(name, list3);
                    }
                    Console.WriteLine(highlight);
                    Thread.Sleep(2500);
                    name = "tasks.json";
                    Console.WriteLine("Далее работаем со следующим списком: ");
                    ToDo[] checklist = ToDo.DeserializeJsonTasks(name);
                    Thread.Sleep(2500);
                    ToDo.IsDoneTask(checklist);
                    ToDo.PrintTasks(checklist);
                    Thread.Sleep(2500);
                    Console.WriteLine("Меняем статус выполнения первой задачи: ");
                    checklist[0].ChangeIsDoneTask();
                    Thread.Sleep(2500);
                    ToDo.PrintTasks(checklist);
                    Thread.Sleep(2500);
                    ToDo.GetCountComplete(checklist);
                    Thread.Sleep(2500);
                    name = "ActualList.json";
                    ToDo.SerializeJsonTasks(name, checklist);
                    Console.WriteLine($"Актуальный список задач записан в файл {name}");
                    Console.WriteLine(highlight);
                }
                else
                {
                    Console.WriteLine("Для выбора дальнейших действий нужно ввести число от 0 до 5.");
                    Console.WriteLine(highlight);
                }
            }
        }
    }
}
