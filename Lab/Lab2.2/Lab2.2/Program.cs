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
            Console.Write("a= ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b= ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
        var c = double.Parse(Console.ReadLine());

        double x1, x2;
        
        var disc = Math.Pow(b, 2) - 4 * a * c;
        if (disc < 0)
        {
            Console.WriteLine("no roots");
        }
        else
        {
            if (disc == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else 
            {
                x1 = (-b + Math.Sqrt(disc)) / (2 * a);
                x2 = (-b - Math.Sqrt(disc)) / (2 * a);
            }
            
            Console.WriteLine("x1 = " + x1 + " x2 = " + x2);
        }
            Console.ReadKey(true);

        }
    }
}
