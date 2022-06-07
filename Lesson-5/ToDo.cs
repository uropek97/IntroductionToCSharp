using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading;
using System.Xml.Serialization;

namespace Lesson_5
{
    [Serializable]
    public class ToDo
    {
        private string _title;
        private bool _isDone;

        #region Properties
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value is null)
                {
                    _title = string.Empty;
                }
                else
                {
                    _title = value;
                }
            }
        }
        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                _isDone = value;
            }
        }
        #endregion
        #region Constructors
        public ToDo()
        {

        }
        public ToDo(string title)
        {
            Title = title;
            IsDone = false;
        }
        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }
        #endregion
        /// <summary>
        /// Запрашиваем у пользователя одну задачу. 
        /// </summary>
        /// <returns>Возвращает задачу ToDo.</returns>
        public static ToDo WriteTask()
        {
            Console.Write("Задача: ");
            ToDo task = new ToDo(Console.ReadLine());
            return task;
        }
        /// <summary>
        /// Запрашиваем у пользователя уже завершенную задачу.
        /// </summary>
        /// <returns></returns>
        public static ToDo WriteCompletedTask()
        {
            Console.Write("Завершенная задача: ");
            ToDo task = new ToDo(Console.ReadLine(), true);
            return task;
        }
        /// <summary>
        /// Запрашиваем у пользователя список активных задач. 
        /// </summary>
        /// <returns>Возвращает список введённых задач ToDo[].</returns>
        public static ToDo[] WriteTasks()
        {
            Console.WriteLine("Сколько задач вы хотите внести?");
            int.TryParse(Console.ReadLine(), out int input);
            ToDo[] list = new ToDo[input];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = WriteTask();
            }
            return list;
        }
        /// <summary>
        /// Запрашиваем у пользователя список задач.
        /// </summary>
        /// <returns>Возвращает список введённых задач ToDo[].</returns>
        public static ToDo[] WriteAllTasks()
        {
            Console.WriteLine("Создание списка задач.");
            Console.WriteLine("Сколько задач вы хотите внести?");
            int.TryParse(Console.ReadLine(), out int input);
            ToDo[] list = new ToDo[input];
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"Задача {i + 1}.");
                Console.Write("Задача уже завершена? 1 => Да, 2 => Нет: ");
                int.TryParse(Console.ReadLine(), out int taskIsDone);
                if (taskIsDone == 1)
                {
                    list[i] = WriteCompletedTask();
                }
                else
                {
                    list[i] = WriteTask();
                }
            }
            return list;
        }
        /// <summary>
        /// Запрашиваем у пользователя список задач. Мне не нравилось, что нужно обязательно в начале вносить количеество задач.
        /// Поэтому улучшил метод, используя List.
        /// </summary>
        /// <returns>Возвращает список введённых задач ToDo[].</returns>
        public static ToDo[] WriteAllTasksUpdate()
        {
            List<ToDo> list = new List<ToDo>();
            Console.WriteLine("Создание списка задач.");
            while (true)
            {
                Console.WriteLine("Новая задача(\"да\") или завершенная?");
                string input = Console.ReadLine();
                ToDo newTask;
                if (input.ToLower().Equals("да"))
                {
                    newTask = WriteTask();
                }
                else
                {
                    newTask = WriteCompletedTask();
                }
                list.Add(newTask);
                Console.Write("Добавить ещё задачу? \"да\" для продолжения: ");
                input = Console.ReadLine();
                if (input.ToLower().Equals("да"))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            ToDo[] checklist = list.ToArray();
            return checklist;
        }


        /// <summary>
        /// Вывод на экран списка задач.
        /// </summary>
        /// <param name="list">Список задач ToDo[]</param>
        public static void PrintTasks(ToDo[] list)
        {
            Console.WriteLine("Список задач: ");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {list[i]}");
            }
        }
        /// <summary>
        /// Изменение статуса задачи
        /// </summary>
        /// Метод здесь появился, потому что все остальные методы static.
        /// Разбирался, как работают не статичные методы. Стало яснее.
        public void ChangeIsDoneTask()
        {
            IsDone = !IsDone;
        }
        /// <summary>
        /// Пользователь выбирает какую задачу из массива ToDo[] он выполнил
        /// </summary>
        /// <param name="list">Список задач ToDo[]</param>
        public static void IsDoneTask(ToDo[] list)
        {
            int input;
            do
            {
                PrintTasks(list);
                Console.WriteLine("Укажите номер задачи, которую выполнили(0 - отмена): ");
                int.TryParse(Console.ReadLine(), out input);
                if (input < 0 || input > list.Length)
                {
                    Console.WriteLine("Вы ввели неверный номер задачи!");
                }
                else if (input == 0)
                {
                    Console.WriteLine("Отмена");
                }
                else
                {
                    if (list[input - 1].IsDone)
                    {
                        Console.WriteLine("Задача уже выполнена.");
                    }
                    else
                    {
                        list[input - 1].ChangeIsDoneTask();
                        Console.WriteLine($"{list[input - 1]}");
                    }
                }
                Thread.Sleep(2500);
            } while (input != 0);

        }
        /// <summary>
        /// Выводит и возвращает количество выполненыых задач из списка
        /// </summary>
        /// <param name="list">Список задач ToDo[]</param>
        /// <returns>Возвращает количество выполненыых задач</returns>
        public static int GetCountComplete(ToDo[] list)
        {
            int count = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].IsDone)
                {
                    count++;
                }
            }

            Console.WriteLine($"Всего задач: {list.Length}. Выполнено: {count}");
            return count;
        }
        //Мне кажется для этих методовов напрашивается один общий виртуальный метод
        //и переопределение его для каждого вида сериализации и десериализации.
        //Но я не знаю правильно ли я вообще мыслю, и как это сделать. 
        #region Serialize
        /// <summary>
        /// Сериализация списка задач в бинарный формат
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="list">список задач ToDo[]</param>
        public static void SerializeBinTasks(string name, ToDo[] list)
        {
            BinaryFormatter binformatter = new BinaryFormatter();
            binformatter.Serialize(new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), list);
            //Без добавления File.Share был Exception System.IO.IOException: "Процесс не может получить доступ к файлу 
        }
        /// <summary>
        /// Сериализация списка задач в формат json
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="list">список задач ToDo[]</param>
        public static void SerializeJsonTasks(string name, ToDo[] list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(name, json);
        }
        /// <summary>
        /// Сериализация списка задач в формат xml
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="list">список задач ToDo[]</param>
        public static void SerializeXmlTasks(string name, ToDo[] list)
        {
            StringWriter strwriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
            serializer.Serialize(strwriter, list);
            string xml = strwriter.ToString();
            File.WriteAllText(name, xml);
        }
        #endregion
        #region Deserialize
        /// <summary>
        /// Десереализация задач из бинарного файла
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <returns>Возвращает список задач ToDo[]</returns>
        public static ToDo[] DeserializeBinTasks(string name)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            ToDo[] list = (ToDo[])formatter.Deserialize(new FileStream(name, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            //Без добавления File.Share был Exception System.IO.IOException: "Процесс не может получить доступ к файлу 

            return list;
        }
        /// <summary>
        /// Десереализация задач из файла формата json
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <returns>Возвращает список задач ToDo[]</returns>
        public static ToDo[] DeserializeJsonTasks(string name)
        {
            string json = File.ReadAllText(name);
            ToDo[] list = JsonSerializer.Deserialize<ToDo[]>(json);
            return list;
        }
        /// <summary>
        /// Десереализация задач из файла формата xml
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <returns>Возвращает список задач ToDo[]</returns>
        public static ToDo[] DeserializeXmlTasks(string name)
        {
            string xml = File.ReadAllText(name);
            StringReader strreadr = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
            ToDo[] list = (ToDo[])serializer.Deserialize(strreadr);
            return list;
        }

        #endregion
        public override string ToString()
        {
            if (IsDone == false)
                return $"[ ] {Title}";
            else
                return $"[x] {Title}";
        }
    }
}
