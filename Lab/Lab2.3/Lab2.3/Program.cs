using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
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

            p = (a + b + c)/2;
            d = p * (p - a) * (p - b) * (p - c);
            if (d < 0) { Console.WriteLine("A triangle does not exist"); }
            else
            {
                s = (double)Math.Sqrt(d);
                Console.WriteLine("result - " + s);
            }
            Console.ReadKey(true);

        }
    }
}
