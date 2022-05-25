using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddText();
            //AddTime();
            //WriteBinaryFile();
            //BinaryFormatter formatter1 = new BinaryFormatter();
            //string str = formatter1.Deserialize(new FileStream("numbers.bin", FileMode.Open)).ToString();
            //Console.WriteLine(str);

            Console.ReadLine();
        }
        static void AddText()
        {
            Console.WriteLine("Введите текст, который будет записан в файл: ");
            File.AppendAllText("text.txt",  $"{Console.ReadLine()} \n");
        }
        static void AddTime()
        {
            string time = DateTime.Now.ToShortTimeString();
            string name = "startup.txt";
            Console.WriteLine($"Текущее время {time} записано в файл {name}");
            File.AppendAllText(name, time + "\n");
        }
        static void WriteBinaryFile()
        {
            string input = Console.ReadLine();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new FileStream("numbers.bin",FileMode.OpenOrCreate), input);
        }
        static void SaveDirectories()
        {
            Directory
        }
    }
}
