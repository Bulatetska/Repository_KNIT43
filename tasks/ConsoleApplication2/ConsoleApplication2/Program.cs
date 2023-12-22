using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            DemonstrateLogicalOperations();

            // task 2
            SolveQuadraticEquation();

            // task 3
            CalculateTriangleArea();
        }

        static void DemonstrateLogicalOperations()
        {
            Console.WriteLine("Демонстрація логічних операцій:");
            bool result = 2 < 4;
            Console.WriteLine($"2 < 4: {result}");

            result = 5 > 10;
            Console.WriteLine($"5 > 10: {result}");

            result = 10 == 10;
            Console.WriteLine($"10 == 10: {result}");

            result = 10 != 100;
            Console.WriteLine($"10 != 100: {result}");

            Console.WriteLine();
        }

        static void SolveQuadraticEquation()
        {
            Console.WriteLine("Розв'язання квадратного рівняння (ax^2 + bx + c = 0):");
            Console.Write("Введіть a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Корені рівняння: x1 = {x1}, x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Рівняння має один корінь: x = {x}");
            }
            else
            {
                Console.WriteLine("Рівняння не має дійсних коренів.");
            }

            Console.WriteLine();
        }

        static void CalculateTriangleArea()
        {
            Console.WriteLine("Знаходження площі трикутника за сторонами:");
            Console.Write("Введіть сторону a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть сторону b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть сторону c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            {
                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                Console.WriteLine($"Площа трикутника: {area}");
            }
            else
            {
                Console.WriteLine("Такого трикутника не існує.");
            }

            Console.WriteLine();
        }
    }
}
