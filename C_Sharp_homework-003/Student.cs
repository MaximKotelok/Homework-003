using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_homework_003
{
    class Student
    {
        private string name, surname, patronymic;
        private string group;
        private int age;


        private int[][] grades;
        static private string[] subjects;


        static Student()
        {
            subjects = new string[] { "Математика", "Фізика", "Хімія", "Історія", "Укр. Мова" };
        }
        public Student(string name, string surname, string patronymic, string group, int age)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.group = group;

        }
        public Student(string name, string surname, string patronymic, string group, int age, int[][] grades) : this(name, surname, patronymic, group, age)
        {
            SetGrades(grades);
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }
        public string GetPatromic()
        {
            return patronymic;
        }

        public string GetGroup()
        {
            return group;
        }

        private int FindSubject(string find)
        {
            int index = Array.IndexOf(subjects, find);
            if (index == -1)
                throw new Exception("Not found");
            return index;
        }

        public void SetGrades(int[][] grades)
        {
            if (grades.Length != subjects.Length)
                throw new Exception("Wrong data error");

            this.grades = new int[grades.Length][];
            for (int i = 0; i < grades.Length; i++)
            {
                this.grades[i] = new int[grades[i].Length];
                for (int j = 0; j < grades[i].Length; j++)
                    this.grades[i][j] = grades[i][j];
            }

        }


        public void SetGradesForSubjects(string subject, int[] grades)
        {
            int index = FindSubject(subject);
            this.grades[index] = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
                this.grades[index][i] = grades[i];
        }


        public static int[] CreateGradesArray()
        {
            Console.WriteLine("Уведи кількість оцінок за цей предмет: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] grades = new int[size];

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"Уведи {i + 1} оцінку: ");
                grades[i] = Convert.ToInt32(Console.ReadLine());

            }
            return grades;
        }

        public static Student CreateStudent()
        {

            string name, surname, patronymic, group;
            int age;

            Console.WriteLine("Ім'я студента: ");
            name = Console.ReadLine();
            Console.WriteLine("Фамілія студента: ");
            surname = Console.ReadLine();
            Console.WriteLine("Ім'я  по батькові студента: ");
            patronymic = Console.ReadLine();
            Console.WriteLine("Введіть группу студента: ");
            group = Console.ReadLine();
            Console.WriteLine("Введіть вік студента: ");
            age = Convert.ToInt32(Console.ReadLine());

            int[][] grades = new int[subjects.Length][];

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine(subjects[i] + ": ");
                grades[i] = Student.CreateGradesArray();
            }
            return new Student(name, surname, patronymic, group, age, grades);
        }

        public static Student CreateRandomStudent()
        {
            string[] names = { "Максим", "Іван", "Степан", "Назар", "Річард", "Юліан", "Мирослав", "Антон", "Степан" };
            string[] surnames = { "Цушко", "Шумейко", "Батейко", "Пилипейко", "Семочко", "Толочко", "Марочко", "Сирко", "Забужко", "Бутко", "Решетько" };
            string[] patronymics = { "Миколайович", "Володимирович", "Олександрович", "Іванович", "Васильович", "Сергійович", "Михайлович", "Вікторович" };
            string[] groups = { "BD121", "PD121", "AD221", "GD221" };
            Random rand = new Random();
            int[][] grades = new int[subjects.Length][];
            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = new int[rand.Next(3, 10)];
                for (int j = 0; j < grades[i].Length; j++)
                    grades[i][j] = rand.Next(2, 13);
            }

            string name = names[rand.Next(0, names.Length)];
            string surname = surnames[rand.Next(0, surnames.Length)];
            string patronymic = patronymics[rand.Next(0, patronymics.Length)];
            string group = groups[rand.Next(0, groups.Length)];
            int age = rand.Next(17, 23);
            return new Student(name, surname, patronymic, group, age, grades);

        }

        public static string SubjectMenu()
        {
            int index;
            do
            {
                for (int i = 0; i < subjects.Length; i++)
                    Console.WriteLine($"{i + 1}. {subjects[i]}");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (index < 0 || index >= subjects.Length);
            return subjects[index];
        }

        public void PrintSubjectInfo(string subject)
        {
            int index = FindSubject(subject);
            Console.WriteLine($"{subjects[index]}: {string.Join(", ", grades[index])}\n");
            Console.WriteLine("Середній бал: "+ grades[index].Average());
            Console.WriteLine("Мінімальний бал: "+ grades[index].Min());
            Console.WriteLine("Максимальний бал: "+ grades[index].Max());
        }

        public override string ToString()
        {
            StringBuilder gradesString = new StringBuilder();
            for (int i = 0; i < subjects.Length; i++)
                gradesString.Append($"{subjects[i]}: {string.Join(", ", grades[i])}\n");
            return $"{group}: {name} {surname} {patronymic}\n{gradesString}";

        }


    }
}
