using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ax^2 + bx + c = 0;
            int a, b, c;
            a = 3;
            b = 5;
            c = 2;
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
                Console.WriteLine("X is less than zero");
            }
            else {
                double x0;
                x0 = -b / (2 * a);
                Console.WriteLine("X = " + x0);
            }

            Console.ReadLine();

            double A, B, C;
            A = 3;
            B = 4;
            C = 5;
            if (A + B <= C || A + C <= B || B + C <= A)
            {
                Console.WriteLine("The triangle does not exist");
            }
            else {
                double p;
                p = (A + B + C) / 2;
                double S;
                S = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                Console.WriteLine("Area of the triangle: " + S);
                
            }
            Console.ReadLine();
        }
    }
}
