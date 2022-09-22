using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool boolVariable = true;
            if(boolVariable)
            {
                System.Console.WriteLine("boolVariable = true;");
            }
            else
            {
                System.Console.WriteLine("boolVariable = false;");
            }
            System.Console.WriteLine();

            boolVariable = false;
            if (boolVariable)
            {
                System.Console.WriteLine("boolVariable = true;");
            }
            else
            {
                System.Console.WriteLine("boolVariable = false;");
            }

            boolVariable = 2 < 4;
            if (boolVariable)
            {
                System.Console.WriteLine("boolVariable = 2 < 4; true;");
            }
            else
            {
                System.Console.WriteLine("boolVariable = 2 < 4; false;");
            }
            if(10!=100)
            {
                System.Console.WriteLine("10!=100! diferent numbers!");
            }
            System.Console.WriteLine();
            System.Console.ReadLine();




      
  
            Console.Write("a = ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            var c = double.Parse(Console.ReadLine());

            double x1, x2;
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("rozv9zkiv nema");
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
            
                Console.WriteLine($"x1 = {x1}; x2 = {x2}");
            }

            Console.ReadKey(true);

        }
    }
}
