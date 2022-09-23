using System;

namespace Lab2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            var c = double.Parse(Console.ReadLine());

            double s, p, d;

            p = (a + b + c) / 2;
            d = p * (p - a) * (p - b) * (p - c);
            if (d < 0) { Console.WriteLine("Трикутника не існує"); }
            else
            {
                s = (double)Math.Sqrt(d);
                Console.WriteLine("Площа трикутника - " + s);
            }
            Console.ReadKey(true);
        }
    }
}
