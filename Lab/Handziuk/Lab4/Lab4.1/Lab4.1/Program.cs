using System;

namespace Lab4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            int i, k = 0;
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
                    k++;
            }
            Console.WriteLine("K = " + k);
            Console.ReadLine();
        }
    }
}
