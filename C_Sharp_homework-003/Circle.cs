using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_homework_003
{
    class Circle
    {
        private double radius;
        private int centerX, centerY;

        public Circle() : this(0, 0, 0) { }
        public Circle(double radius, int centerX, int centerY)
        {
            this.radius = radius;
            this.centerX = centerX;
            this.centerY = centerY;
        }

        public double GetCircleArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * radius;
        }

        public bool IsInCircle(int x, int y)
        {
            return Math.Pow((x - centerX), 2) + Math.Pow((y - centerY), 2) < Math.Pow(radius, 2);
        }

        public override string ToString()
        {
            return $"Коло: x = {centerX}, y = {centerY} | R = {radius}";
        }

        public static Circle CreateCircle()
        {
            int x, y, radius;
            Console.WriteLine("Уведи X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Уведи Y: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Уведи радіус: ");
            radius = Convert.ToInt32(Console.ReadLine());
            return new Circle(radius, x, y);
        }
    }
}
