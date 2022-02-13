
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_homework_003
{

    public delegate void SomeTask();



    class Menu
    {
        private List<Task> tasks;
        class Task
        {

            private string description;
            ConsoleColor border_color;
            string border;
            SomeTask task;

            public string Description
            {
                get { return description; }
            }

            public Task(string description)
            {
                this.description = description;
                border = "";
            }
            public Task(string description, SomeTask task) : this(description)
            {
                this.task = task;
            }
            public void Start()
            {
                task.Invoke();
            }
            public void AddBorder(string text, ConsoleColor border_color)
            {
                this.border = text;
                this.border_color = border_color;
            }

            public void PrintBorder()
            {
                if (border.Length != 0)
                {

                    Console.ForegroundColor = border_color;
                    Console.WriteLine($"*-=-=- {border} -=-=-*");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
        public Menu()
        {
            tasks = new List<Task>();
            tasks.Add(new Task("Вихід"));
        }

        public void AddNewTask(string description, SomeTask task)
        {
            tasks.Add(new Task(description, task));
        }

        public void AddNewBorder(string text, ConsoleColor color = ConsoleColor.White)
        {
            tasks[tasks.Count - 1].AddBorder(text, color);
        }

        public void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"*-=-=- {System.Reflection.Assembly.GetEntryAssembly().GetName().Name} -=-=-*");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i} - {tasks[i].Description}");
                    tasks[i].PrintBorder();

                }
                int choice;
                do
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice < 0 || choice > tasks.Count);

                if (choice == 0)
                    break;

                tasks[choice].Start();

                Console.WriteLine("Натисни будь-яку кнопку що би продовжити...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }


    }
}

