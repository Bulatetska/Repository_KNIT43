using System;

namespace Lab2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a= ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b= ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            var c = double.Parse(Console.ReadLine());

            double x1, x2;

            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("Квадратне рівняння не має коренів");
            }
            else
            {
                if (discriminant == 0)
                {
                    x1 = -b / (2 * a);
                    x2 = x1;
                }
                else
                {
                    x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                }

                Console.WriteLine("x1 = " + x1 + " x2 = " + x2);
            }
            Console.ReadKey(true);
        }
    }
}
