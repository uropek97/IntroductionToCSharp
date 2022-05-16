using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool average = SearchAvrTemp();
            byte month = NameMonth();
            IsEven();
            //PrintReceipt();
            IsRainyWinter(month, average);
            ShowSchedule();

            Console.ReadLine();
        }
        /// <summary>
        /// Задача 1. 
        /// </summary>
        static bool SearchAvrTemp()
        {
            Console.Write("Введите минимальную температуру за сутки: ");
            double min = double.Parse(Console.ReadLine());
            Console.Write("Введите максимальную температуру за сутки: ");
            double max = double.Parse(Console.ReadLine());
            double average = (min + max) / 2;
            Console.WriteLine($"Среднесуточная температура: {average}");
            if (average > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Задача 2.
        /// </summary>
        static byte NameMonth()
        {
            Console.Write("Введите номер текущего месяца: ");
            byte month = byte.Parse(Console.ReadLine());
            Console.WriteLine($"Текущий месяц: {(Months)month}");
            return month;
        }
        /// <summary>
        /// Перечисление месяцев
        /// </summary>
        [Flags]
        enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        /// <summary>
        /// Задача 3.
        /// </summary>
        static void IsEven()
        {
            Console.Write("Введите целое число: ");
            int numb = int.Parse(Console.ReadLine());
            if (numb == 0)
            {
                Console.WriteLine("Вы победили. Вы ввели \"самое чётное\" число.");
            }
            else if (numb % 2 == 0)
            {
                Console.WriteLine("Чётное число");
            }
            else
            {
                Console.WriteLine("Нечётное число");
            }
        }
        /// <summary>
        /// Задача 4.
        /// </summary>
        static void PrintReceipt()
        {
            Console.WriteLine("ООО \"Шериф\"");
            Console.WriteLine("Супермаркет \"Шериф-{22}\"");
            Console.WriteLine("Касса #{1}");
            string highlight = "---------------------------";
            Console.WriteLine(highlight);
            Console.WriteLine("{type} No: {count}");
            Console.WriteLine("Зал {numb}, КАССА: {numbcas} Чек: {1390871}");
            Console.WriteLine("Кассир: {name}");
            Console.WriteLine(highlight);
            Console.WriteLine("{amount} {product}");
            Console.WriteLine("space {amount}x{cost}={amount*cost}");
            Console.WriteLine("{amountpoz} позиций {unknown}");
        }
        /// <summary>
        /// Задача 5.
        /// </summary>
        /// <param name="month">Номер месяца</param>
        /// <param name="avrTemp">Показатель среднесуточной температуры за день. Если больше нуля - true</param>
        static void IsRainyWinter(byte month, bool avrTemp)
        {
            if ((month == 1 || month == 2 || month == 12) && avrTemp)
            {
                Console.WriteLine("Дождливая зима");
            }
            else
            {
                Console.WriteLine("Не дождливая зима");
            }
        }
        /// <summary>
        /// Задача 6.
        /// </summary>
        static void ShowSchedule()
        {
            //Расписание взято из примеров в задании
            //Не уверен, что задача решена верно, слишком просто решил, и слишком простое решение. Возможно условия не до конца понял.
            var schedule1office = 0b_0011110;
            var schedule2office = 0b_1111111;
            Console.WriteLine($"Офис номер один работает в: {(DayOfWeek)schedule1office}");
            Console.WriteLine($"Офис номер два работает в: {(DayOfWeek)schedule2office}");
            Console.Write("Введите битовую маску (1 число - воскресенье, 7 - понедельник): ");
            int yourmask = Convert.ToInt32(Console.ReadLine(), 2);
            Console.WriteLine($"Офис работает в: {(DayOfWeek)yourmask}");
        }
        /// <summary>
        /// Перечисление дней недели.
        /// </summary>
        // Пытался перевернуть битовую маску, чтобы понедельник шёл первым битом, но результата, чтобы и биты и дни недели шли по порядку(с пн по вс) добиться не удалось. 
        [Flags]
        enum DayOfWeek
        {
            Понедельник = 0b_0000001,
            Вторник = 0b_0000010,
            Среда = 0b_0000100,
            Четверг = 0b_0001000,
            Пятница = 0b_0010000,
            Суббота = 0b_0100000,
            Воскресенье = 0b_1000000
        }
    }
}
