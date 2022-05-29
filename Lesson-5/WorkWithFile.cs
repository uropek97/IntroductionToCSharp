using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson_5
{
    class WorkWithFile
    {
        /// <summary>
        /// Записывает текст введённый пользователем в файл text.txt
        /// </summary>
        public static void AddText()
        {
            Console.WriteLine("Введите текст, который будет записан в файл: ");
            File.AppendAllText("text.txt", $"{Console.ReadLine()} \n");
        }
        /// <summary>
        /// Добавляет время выполнения этого метода в файло startup.txt
        /// </summary>
        public static void AddTime()
        {
            string time = DateTime.Now.ToShortTimeString();
            string name = "startup.txt";
            Console.WriteLine($"Текущее время {time} записано в файл {name}");
            File.AppendAllText(name, $"{time} \n");
        }
        /// <summary>
        /// Принимает ввод пользователем чисел от 0 до 255 и записывает введённую строку в файл numbers.bin
        /// </summary>
        public static void WriteBinaryFile()
        {
            Console.WriteLine("Введите числа от 0 до 255 разделяя их пробелом: ");
            string input = Console.ReadLine();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new FileStream("numbers.bin", FileMode.OpenOrCreate), input);
        }
    }
}
