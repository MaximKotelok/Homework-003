using System;

namespace C_Sharp_homework_003
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.AddNewTask("", new SomeTask(() => { }));
            //menu.AddNewTask("", new SomeTask(() => { }));
            menu.Start();
        }
    }
}
