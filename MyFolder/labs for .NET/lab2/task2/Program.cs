
using System;

class Program
{
    static void Main()
    {
        double[,] A =
        {
            { 2.5, 7.0, 3.2 },
            { 4.1, 7.0, 1.5 },
            { 6.3, 2.0, 7.0 }
        };

        int n = 3;
        double max = A[0, 0];

        Console.WriteLine("Початкова матриця:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(A[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[i, j] > max)
                {
                    max = A[i, j];
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[i, j] == max)
                {
                    A[i, j] = 0;
                }
            }
        }

        Console.WriteLine("Змінена матриця:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(A[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
