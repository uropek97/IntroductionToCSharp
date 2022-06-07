using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_5
{
    /*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — 
     * срекурсией и без */
    public class WorkWithDirectories
    {
        /// <summary>
        /// Метод распечатывает дерево каталогов и файлов с рекурсией.
        /// </summary>
        /// <param name="dir">Корневой каталог.</param>
        /// <param name="indent">Изначальный отступ.</param>
        /// <param name="lastDir">Булево значение последний ли каталог. На вход нужен true.</param>
        /// <param name="name">имя файла, куда запишестя данное дерево.</param>
        public static void PrintDirRec(DirectoryInfo dir, string indent, bool lastDir, string name)
        {
            Console.Write(indent);
            Console.Write(lastDir ? "└─" : "├─");
            string str = lastDir ? "└─" : "├─";
            string infile = $"{indent}{str}";
            indent += lastDir ? "  " : "│  ";
            Console.WriteLine(dir.Name);
            infile += dir.Name;
            File.AppendAllText(name, $"{infile}\n");
            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                string indent2 = indent;
                indent2 += lastDir ? "│  " : "";
                infile = indent2;
                Console.Write($"{indent2}");
                Console.WriteLine(files[i]);
                infile += files[i];
                File.AppendAllText(name, $"{infile}\n");
            }
            DirectoryInfo[] subDirs = dir.GetDirectories();

            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintDirRec(subDirs[i], indent, i == subDirs.Length - 1, name);
            }
        }
        /// <summary>
        /// Метод распечатывает дерево каталогов и файлов без рекурсии. Метод недоделан, как нормально обработать вложенные каталоги, так и не понял.
        /// </summary>
        /// <param name="root">Корневой каталог</param>
        /// <param name="name">имя файла, куда запишестя данное дерево.</param>
        public static void PrintDir(DirectoryInfo root, string name)
        {
            Queue<DirectoryInfo > dirs = new Queue<DirectoryInfo>(20);
            Console.Write("└─");
            Console.WriteLine(root.Name);
            string infile = $"└─{root.Name} \n";
            File.AppendAllText(name, infile);
            DirectoryInfo[] subDirs = root.GetDirectories();
            for (int i = 0; i < subDirs.Length; i++)
            {
                dirs.Enqueue(subDirs[i]);
            }
            FileInfo[] files = root.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.Write("  │ ");
                Console.WriteLine(file.Name);
                infile = $"  │ {file.Name} \n";
                File.AppendAllText(name, infile);
            }
            do
            {
                DirectoryInfo currentDir = dirs.Dequeue();
                subDirs = currentDir.GetDirectories();
                for (int i = 0; i < subDirs.Length; i++)
                {
                    dirs.Enqueue(subDirs[i]);
                }
                
                files = currentDir.GetFiles();
                if (dirs.Count == 0)
                {
                    Console.Write("     └─ ");
                    Console.WriteLine(currentDir.Name);
                    infile = $"     └─ {currentDir.Name} \n";
                    File.AppendAllText(name, infile);
                }
                else
                {
                    Console.Write("  ├─ ");
                    Console.WriteLine(currentDir.Name);
                    infile = $"  ├─ {currentDir.Name} \n";
                    File.AppendAllText(name, infile);
                }

                foreach (FileInfo file in files)
                {
                    if (dirs.Count == 0)
                    {
                        Console.Write("      │ ");
                        Console.WriteLine(file.Name);
                        infile = $"      │ {file.Name} \n";
                        File.AppendAllText(name, infile);
                    }
                    else
                    {
                        Console.Write("  │ ");
                        Console.WriteLine(file.Name);
                        infile = $"  │ {file.Name} \n";
                        File.AppendAllText(name, infile);
                    }

                }
            } while (dirs.Count > 0);
        }
    }
}
