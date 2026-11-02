
using System;

class Program
{
    static void Main()
    {
        int[,] A =
        {
            { 2, 4, 6 },
            { 8, 10, 12 }
        };

        int n = 2;
        int m = 3;
        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum += A[i, j];
            }
        }

        double average = sum / (n * m);

        Console.WriteLine("Середнє арифметичне: " + average);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (A[i, j] < average)
                {
                    A[i, j] = -1;
                }
                else if (A[i, j] > average)
                {
                    A[i, j] = 1;
                }
            }
        }

        Console.WriteLine("Змінена матриця:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(A[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
