using System;

namespace Lab4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] D = new int[5, 5];
            int max = D[0, 0];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    D[i, j] = i + j;

                    Console.Write(D[i, j]);
                }
                Console.WriteLine();

            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    if (D[i, j] > max)
                        max = D[i, j];

                }
                Console.WriteLine("Максимальний елемент " + max);

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    if (D[i, j] == 0)
                    {
                        D[i, j] = 0;
                    }
                    Console.Write(D[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
