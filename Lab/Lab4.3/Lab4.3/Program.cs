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
            float[] a = new float[10];
            Random rand = new Random();
            int numb = 0, n = 0;

            for (int i = 0; i < 10; i++)
            {
                a[i] = rand.Next(10);
            Console.Write(a[i]);
            }
            Console.WriteLine();
            
            for (int i = 0; i < 9; i++)
            {
                if (a[i]>0 && a[i+1]>0) {
                    numb++;
                }
              
            }
            for (int i = 0; i < 9; i++)
            {
                if (a[i] == 0 && a[i + 1] == 0)
                {
                    n++;
                }
            }
            Console.WriteLine("Додатнi числа: " + numb);
            Console.WriteLine("Нулi: " + n);

            Console.ReadLine();

        }
    }
}
