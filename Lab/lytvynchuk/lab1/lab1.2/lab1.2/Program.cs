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


        }
    }
}
