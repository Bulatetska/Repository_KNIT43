
using System;

class Program
{
    static void Main()
    {
        int[,] A =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            { 3, 4, 5, 6, 7, 8, 9, 10, 11 },
            { 4, 5, 6, 7, 50, 9, 10, 11, 12 },
            { 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            { 6, 7, 8, 9, 10, 11, 12, 13, 14 }
        };

        int max = A[0, 0];
        int row = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (A[i, j] > max)
                {
                    max = A[i, j];
                    row = i;
                }
            }
        }

        int sum = 0;

        for (int j = 0; j < 9; j++)
        {
            sum += A[row, j];
        }

        Console.WriteLine("Максимальний елемент: " + max);
        Console.WriteLine("Номер рядка: " + (row + 1));
        Console.WriteLine("Сума рядка: " + sum);
    }
}
