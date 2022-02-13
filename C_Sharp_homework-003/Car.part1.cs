using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_homework_003
{
    partial class Car
    {
        private string name;
        private string company;
        private string color;
        private int year;
        private int engineCapacity;
        private double price;

        private static int numberOfCarsPurchased;
        private static double totalRevenue;

        static Car()
        {
            numberOfCarsPurchased = 0;
            totalRevenue = 0;
        }

        public Car() : this("None", "None", "None", 0, 0, 0)
        {

        }

        public Car(string name, string company, string color, int year)
        {
            this.name = name;
            this.company = company;
            this.color = color;
            this.year = year;
        }

        public Car(string name, string company, string color, int year, int engineCapacity, double price) : this(name, company, color, year)
        {

            this.engineCapacity = engineCapacity;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetCompany()
        {
            return company;
        }

        public void SetCompany(string company)
        {
            this.company = company;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string color)
        {
            this.color = color;
        }
        public int GetYear()
        {
            return year;
        }

        public void SetYear(int year)
        {
            this.year = year;
        }
        public int GetEngineCapacity()
        {
            return engineCapacity;
        }

        public void SetEngineCapacity(int engineCapacity)
        {
            this.engineCapacity = engineCapacity;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public static int GetNumberOfCarsPurchased()
        {
            return numberOfCarsPurchased;
        }
        public static double GetTotalRevenue()
        {
            return totalRevenue;
        }

        public static bool ExchangeUnderWarranty(ref Car oldCar, ref Car newCarFromStock, ref double money)
        {
            if (oldCar.price + money >= newCarFromStock.price)
            {
                totalRevenue -= oldCar.price;
                totalRevenue += newCarFromStock.price;
                money -= (newCarFromStock.price - oldCar.price);
                money = Math.Round(money, 2);
                Car tmp = oldCar;
                oldCar = newCarFromStock;
                newCarFromStock = tmp;
                return true;
            }
            return false;
        }

    }
}
