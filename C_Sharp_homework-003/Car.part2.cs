using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_homework_003
{
    partial class Car
    {
        public bool Buy(ref double clientMoney)
        {
            if (price <= clientMoney)
            {
                clientMoney = Math.Round(clientMoney - price, 2);
                numberOfCarsPurchased++;
                totalRevenue += price;
                return true;
            }
            return false;
        }

        public static Car CreateRandomCar()
        {
            Random rand = new Random();
            string[] names = { "Acura", "Aston Martin", "Bentley", "Bugatti", "Buick", "Cadillac", "Chery" };
            string[] companyes = { "Volkswagen", "Toyota", "Honda", "Ford", "Fiat", "Groupe PSA", "BMW", "Daimler", "Suzuki" };
            string[] colors = {"Black","Blue", "Gray", "Yellow", "Red", "White","Silver"};
            int year = rand.Next(2006, 2022);
            int engineCapacity = rand.Next(1600, 5000);
            double price = rand.Next(1000, 2500)+rand.NextDouble();
            price = Math.Round(price, 2);
            return new Car(names[rand.Next(0, names.Length)], companyes[rand.Next(0, companyes.Length)], colors[rand.Next(0, colors.Length)], year, engineCapacity, price);
        }

        public static int PrintCar(Car[] cars, bool showIndex = false)
        {
            int numberOfCar = cars.Length;
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].name == "None")
                {
                    numberOfCar = i;
                    break;
                }
                Console.WriteLine((showIndex ? $"{(i + 1)}. ": "")+$"{cars[i]} | Потужність двигуна: {cars[i].engineCapacity} | Ціна: {cars[i].price}$");
            }
            return numberOfCar;
        }

        public static int CarMenu(Car[] cars)
        {
            int ignore = PrintCar(cars, true);

            int choice;
            if (ignore == 0)
                throw new Exception("No machines found");
            do
            {
                choice = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (choice < 0 || choice >= ignore);
            return choice;
        }

        public override string ToString()
        {
            return company + " " + name + " " + color + "| Рік випуску: " + year;
        }
    }
}
