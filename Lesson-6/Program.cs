using System;
using System.Diagnostics;
using System.Threading;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //запускаю процессы, которые можно будет потом завершить по ID
            Process.Start("notepad.exe");
            //Эти два процесса убить не получается. Хотя я проверял в списке 
            Process.Start("tasklist.exe");
            Process.Start("taskkill.exe");
            //Если выставить паузу, процессы tasklist и taskkill и не появятся в списке.
            //Видимо они очень быстро завершаются сами. Использовал их, потому что их предлагает
            //использовать методичка. 
            Thread.Sleep(2000);
            Process[] processes = Process.GetProcesses();
            WorkWithProcesses.PrintMyProcess(processes);
            string input;
            do
            {
                Console.Write("Хотите завершить какой-то процесс? \"Да\" для продолжения: ");
                input = Console.ReadLine();
                if (input.ToLower().Equals("да"))
                {
                    WorkWithProcesses.KillMyProcess();
                    Thread.Sleep(2000); //Без этой паузы завершённый процесс ещё останется в списке. 
                    processes = Process.GetProcesses();
                    WorkWithProcesses.PrintMyProcess(processes);
                }
            }
            while (input.ToLower().Equals("да"));

            Console.ReadLine();
        }
    }
}
