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

            int[,] D = new int[5, 7];
            int Sum = 0, SA = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    D[i, j] = i + j;
                    Console.Write(D[i,j]);
                    Sum = Sum + D[i, j];
                   }
                Console.WriteLine();
            }
            SA = Sum / (5 * 7);
            Console.WriteLine("Середнє арифметичне " + SA);
            Console.WriteLine(" Результуючий масив: ");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (D[i, j] < SA) { D[i, j] = -1; }
                    if (D[i, j] > SA) { D[i, j] = 1; }
                    Console.Write(D[i, j]);
                } Console.WriteLine();
            }
            
            Console.ReadLine();
        }
    }
}
