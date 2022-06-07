using System;
using System.Diagnostics;

namespace Lesson_6
{
    class WorkWithProcesses
    {
        /// <summary>
        /// Метод завершает процесс по указанному ID.
        /// </summary>
        public static void KillMyProcess()
        {
            Console.Write("Введите процесс, который хотите завершить по ID: ");
            int.TryParse(Console.ReadLine(), out int input);
            try
            {
                Process.GetProcessById(input).Kill();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Выводит в консоль список текущих процессов. процессы notepad.exe, tasklist.exe, taskkill.exe выделяются красным цветом.
        /// </summary>
        /// <param name="processes">Массив процессов, который нужно вывести на экран.</param>
        public static void PrintMyProcess(Process[] processes)
        {
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName.Equals("notepad") || processes[i].ProcessName.Equals("tasklist")
                    || processes[i].ProcessName.Equals("taskkill"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i + 1}) ID: {processes[i].Id} Name: {processes[i].ProcessName}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i + 1}) ID: {processes[i].Id} Name: {processes[i].ProcessName}");
                }
            }
        }
    }
}
