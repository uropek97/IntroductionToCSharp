using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = -1;
            double average = -273;
            byte month = 0;
            while (true)
            {
                Console.WriteLine("1 => Задча 1. Средняя температура");
                Console.WriteLine("2 => Задча 2. Название месяца");
                Console.WriteLine("3 => Задча 3. Чётность числа");
                Console.WriteLine("4 => Задча 4. Чек");
                Console.WriteLine("5 => Задча 5. Определение дождливая зими или другое");
                Console.WriteLine("6 => Задча 6. Расписание офисов");
                Console.WriteLine("0 => Выход из программы");
                Console.Write("Выберите номер задачи: ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    average = SearchAvrTemp();
                }
                else if (input == 2)
                {
                    month = NameMonth();
                }
                else if (input == 3)
                {
                    IsEven();
                }
                else if (input == 4)
                {
                    PrintReceipt();
                }
                else if (input == 5)
                {
                    if(month == 0 || average == -273)
                    {
                        Console.WriteLine("Прежде всего нужно выполнить первую задачу");
                        continue;
                    }
                    IsRainyWinter(month, average);
                }
                else if (input == 6)
                {
                    ShowSchedule();
                }
                else if (input == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Нет такой задачи");
                }
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Задача 1. Средняя температура
        /// </summary>
        static double SearchAvrTemp()
        {
            Console.Write("Введите минимальную температуру за сутки: ");
            double min = double.Parse(Console.ReadLine());
            Console.Write("Введите максимальную температуру за сутки: ");
            double max = double.Parse(Console.ReadLine());
            double average = (min + max) / 2;
            Console.WriteLine($"Среднесуточная температура: {average}");
            return average;
        }
        /// <summary>
        /// Задача 2. Название месяца
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
        /// Задача 3. Чётность числа
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
        /// Задача 4. Чек
        /// </summary>
        static void PrintReceipt()
        {
            string highlight = "----------------------------------------";
            string city = "г.Бендеры";
            string adres = "ул.Бендерского Восстания, 5А";
            string typeOfOp = "Пополнение счёта";
            string name = "Чебота Игорь Александрович";
            long account = 2555_7894_4561_1234;//счёт от балды написан
            string currency = "RUP";//Приднестровский рубль - RUP
            int payment = 100;
            int commission = 0;
            int code = 285133645;//полагаю код операции как-то связан с предыдущими операциями, наверное в методе должен храниться какой-то счётчик
            string paymentmeth = "наличными";
            Console.WriteLine($"{"АГРОПРОМБАНК".PadLeft(23)}");
            Console.WriteLine(highlight);
            //на чеке дата и время, когда он выдан
            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"{city}, {adres}");
            Console.WriteLine($"{typeOfOp}");
            Console.WriteLine($"Клиент {name.PadLeft(33)}");
            Console.WriteLine($"Счёт {account.ToString().PadLeft(35)}");
            Console.WriteLine($"Валюта пополнения {currency.PadLeft(22)}");
            Console.WriteLine($"Сумма платежа {payment.ToString().PadLeft(26)}");
            Console.WriteLine($"Сумма комиссии {commission.ToString().PadLeft(25)}");
            Console.WriteLine($"Сумма операции {(payment + commission).ToString().PadLeft(25)}");
            Console.WriteLine($"Код операции {code.ToString().PadLeft(27)}");
            Console.WriteLine($"Оплата {paymentmeth.PadLeft(33)}");
            Console.WriteLine(highlight);
        }
        /// <summary>
        /// Задача 5. Определение дождливая зими или другое
        /// </summary>
        /// <param name="month">Номер месяца</param>
        /// <param name="avrTemp">Показатель среднесуточной температуры за день. Если больше нуля - true</param>
        static void IsRainyWinter(byte month, double avrTemp)
        {
            if ((month == 1 || month == 2 || month == 12) && avrTemp > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
            else
            {
                Console.WriteLine("Не дождливая зима");
            }
        }
        /// <summary>
        /// Задача 6. Расписание офисов
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
            //строку типа "1100111 приведёт к типу int в двоичном виде 
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
