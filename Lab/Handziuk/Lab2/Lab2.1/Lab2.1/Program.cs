using System;

namespace Lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolVariable = true;

            if (boolVariable)
            {
                System.Console.WriteLine("boolVariable = true; ---Iстина!");
            }
            else
            {
                System.Console.WriteLine("boolVariable = false; ---Хибно!");
            }
            System.Console.WriteLine();

            boolVariable = false;
            if (boolVariable)
            {
                System.Console.WriteLine("boolVariable = false; Iстина!");
            }
            else
            {
                System.Console.WriteLine("boolVariable = false; Хибно!");
            }

            boolVariable = 2 < 4;

            if (boolVariable)
            {
                System.Console.WriteLine("boolVariable = 2 < 4;  Iстина!");
            }
            else
            {
                System.Console.WriteLine("boolVariable = 2 < 4; Хибно!");
            }

            if (10 != 100)
            {
                System.Console.WriteLine("10 != 100! Рiзнi числа!");
            }
            System.Console.WriteLine();
            System.Console.ReadLine();
        }
    }
}
