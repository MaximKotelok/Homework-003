using System;
using System.Collections.Generic;

namespace C_Sharp_homework_003
{
    class Program
    {
        static Student GetStudentFromList(List<Student> students)
        {

            int index;
            if (students.Count != 0)
            {

                for (int i = 0; i < students.Count; i++)
                    Console.WriteLine($"{i + 1}. {students[i].GetGroup()} - {students[i].GetName()} {students[i].GetSurname()} {students[i].GetPatromic()}");


                do
                {
                    index = Convert.ToInt32(Console.ReadLine()) - 1;
                } while (index < 0 || index >= students.Count);
            }
            else
                throw new Exception("Empty Student list error");
            return students[index];
        }

        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.AddNewTask("", new SomeTask(() =>
            {
                List<Student> students = new List<Student>();
                int choice;
                do
                {
                    Console.WriteLine(new string('=',75));
                    Console.WriteLine("0. Вихід");
                    Console.WriteLine($"1. Передивитися усіх студентів ({students.Count} студентів)");
                    Console.WriteLine("2. Додати студента вручну");
                    Console.WriteLine("3. Додати рандомного студента");
                    Console.WriteLine("4. Передивитися характеристику студента по предмету");
                    Console.WriteLine("5. Змінити оцінки за предмет");
                    Console.WriteLine(new string('=',75));
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                        break;
                    try
                    {

                    switch (choice)
                    {
                        case 1:
                            foreach(Student item in students)
                                Console.WriteLine(item);
                            break;
                        case 2:
                            students.Add(Student.CreateStudent());
                            break;
                        case 3:
                            students.Add(Student.CreateRandomStudent());
                            break;
                        case 4:
                            GetStudentFromList(students).PrintSubjectInfo(Student.SubjectMenu());
                            break;
                        case 5:
                            GetStudentFromList(students).SetGradesForSubjects(Student.SubjectMenu(), Student.CreateGradesArray());
                            break;
                    }
                    }catch(Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                } while (true);
            }));
            //menu.AddNewTask("", new SomeTask(() => { }));
            menu.Start();
        }
    }
}
