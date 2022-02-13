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

        static void ShiftCars(Car[] cars, int index)
        {
            for (int i = index; i < cars.Length - 1; i++)
                cars[i] = cars[i + 1];
            cars[cars.Length - 1] = new Car();
        }

        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.AddNewTask("Student", new SomeTask(() =>
            {
                List<Student> students = new List<Student>();
                int choice;
                do
                {
                    Console.WriteLine(new string('=', 75));
                    Console.WriteLine("0. Вихід");
                    Console.WriteLine($"1. Передивитися усіх студентів ({students.Count} студентів)");
                    Console.WriteLine("2. Додати студента вручну");
                    Console.WriteLine("3. Додати рандомного студента");
                    Console.WriteLine("4. Передивитися характеристику студента по предмету");
                    Console.WriteLine("5. Змінити оцінки за предмет");
                    Console.WriteLine(new string('=', 75));
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                        break;
                    try
                    {

                        switch (choice)
                        {
                            case 1:
                                foreach (Student item in students)
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
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                } while (true);
            }));

            menu.AddNewTask("Circle", new SomeTask(() =>
            {
                Circle circle = Circle.CreateCircle();
                int choice;
                do
                {
                    string info = circle.ToString();
                    Console.WriteLine(new string('=', info.Length + 2));
                    Console.WriteLine("|" + circle + "|");
                    Console.WriteLine(new string('=', info.Length + 2));
                    Console.WriteLine("0. Вихід");
                    Console.WriteLine("1. Перестворити коло");
                    Console.WriteLine("2. Отримати площу");
                    Console.WriteLine("3. Довжина окружності");
                    Console.WriteLine("4. Перевірити чи точка є у колі");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 0)
                        break;

                    switch (choice)
                    {
                        case 1:
                            circle = Circle.CreateCircle();
                            break;
                        case 2:
                            Console.WriteLine($"Площа: {circle.GetCircleArea()}");
                            break;
                        case 3:
                            Console.WriteLine($"Довжина окружності: {circle.GetCircumference()}");
                            break;
                        case 4:
                            int x, y;
                            Console.WriteLine("Уведи X: ");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Уведи Y: ");
                            y = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ця точка " + (circle.IsInCircle(x, y) ? "" : "не ") + "є частиною кола");
                            break;
                    }

                } while (true);



            }));
            menu.AddNewTask("Car", new SomeTask(() =>
            {
                Console.WriteLine("Уведи свій бюджет: ");
                double money = Convert.ToDouble(Console.ReadLine());

                Car[] stock = new Car[5];
                Car[] garage = new Car[stock.Length];
                int emptyIndex = garage.Length;
                for (int i = 0; i < stock.Length; i++)
                    stock[i] = Car.CreateRandomCar();
                for (int i = 0; i < garage.Length; i++)
                    garage[i] = new Car();

                do
                {
                    Console.WriteLine(new string('=', 75));
                    Car.PrintCar(stock);
                    Console.WriteLine(new string('=', 75));
                    Console.WriteLine("Усього було продано: " + Car.GetNumberOfCarsPurchased() + " машин");
                    Console.WriteLine("Прибуток автосалону: " + Math.Round(Car.GetTotalRevenue(),2) + "$");
                    Console.WriteLine(new string('=', 75));
                    Console.WriteLine($"Гроші: {money}$");
                    Console.WriteLine($"Кількість машин у гаражі: {garage.Length - emptyIndex}");
                    Console.WriteLine(new string('=', 75));
                    Console.WriteLine("0. Вихід");
                    Console.WriteLine("1. Купити машину");
                    Console.WriteLine("2. Обміняти машину");
                    Console.WriteLine("3. Подивитися свої машини");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 0)
                        break;
                    try
                    {

                        switch (choice)
                        {
                            case 1:
                                int index = Car.CarMenu(stock);
                                if (stock[index].Buy(ref money))
                                {
                                    garage[garage.Length - emptyIndex--] = stock[index];
                                    ShiftCars(stock, index);
                                }
                                else
                                {
                                    Console.WriteLine("Не вистачає грошей");
                                }
                                break;
                            case 2:
                                if (garage.Length - emptyIndex == 0)
                                    throw new Exception("Empty garage!");
                                if (stock[0].GetName() == "None")
                                    throw new Exception("Empty stock!");
                                int oldCarIndex, newCarIndex;
                                Console.WriteLine("Машину ЯКУ замінити: ");
                                oldCarIndex = Car.CarMenu(garage);
                                Console.WriteLine("Машину НА ЯКУ замінити: ");
                                newCarIndex = Car.CarMenu(stock);
                                if (!Car.ExchangeUnderWarranty(ref garage[oldCarIndex], ref stock[newCarIndex], ref money))
                                    Console.WriteLine("Не вистачає грошей!");
                                break;
                            case 3:
                                Console.Write("\n\n");
                                foreach (Car item in garage)
                                {
                                    if (item.GetName() == "None")
                                        continue;
                                    Console.WriteLine(item + $" | Потужність двигуна: {item.GetEngineCapacity()}");
                                }
                                break;
                        }

                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                } while (true);
            }));
            menu.Start();
        }
    }
}
