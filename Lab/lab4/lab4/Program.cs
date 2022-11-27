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
            int[] arr = new int[10];

            int i, q = 0;
            for (i = 0; i < 10; i++)
            {
                arr[i] = i;
                Console.WriteLine(arr[i]);
            }


            int max = arr[0];
            int n = 1;
            for (i = 1; i < 10; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                n = i;
            }
            Console.WriteLine("MAX = " + max);
            Console.WriteLine("Position = " + n);

            for (i = 1; i < 10; i++)
            {
                if (max == arr[i])
                    q++;
            }
            Console.WriteLine("Q = " + q);
            Console.ReadLine();

        }
    }
}
