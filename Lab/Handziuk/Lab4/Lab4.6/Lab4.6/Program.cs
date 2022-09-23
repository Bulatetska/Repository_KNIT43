using System;

namespace Lab4._6
{
    class Program
    {
        static void Main(string[] args)
        {

            float[] a = new float[10];
            Random rand = new Random();
            float sum = 0;
            int i;
            for (i = 0; i < 10; i++)
            {
                a[i] = rand.Next(10);
                Console.Write(a[i]);
            }

            i = 0;
            while (i < 10)
            {
                sum += a[i];
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Сума: " + sum);

            Console.ReadLine();
        }
    }
}
