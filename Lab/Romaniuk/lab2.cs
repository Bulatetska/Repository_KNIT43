using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = 2;
            b = 3;
            c = 5;
            double D;
            D = (b * b) - (4 * a * c);
            if (D > 0)
            {
                double x1, x2;
                x1 = (-b - Math.Sqrt(D)) / (2 * a);
                x2 = (-b + Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("X1 = " + x1);
                Console.WriteLine("X2 = " + x2);
            }
            else if (D < 0)
            {
                Console.WriteLine("X<0");
            }
            else {
                double x0;
                x0 = -b / (2 * a);
                Console.WriteLine("X = " + x0);
            }

            Console.ReadLine();

            double a, b, c;
            A = 2;
            B = 3;
            C = 4;
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("Not exist");
            }
            else {
                double p;
                p = (a + b + c) / 2;
                double S;
                S = Math.Sqrt(p * (p - a) * (p - b) * (p - b));
                Console.WriteLine("Area: " + S);
                
            }
            Console.ReadLine();
        }
    }
}
