using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[6, 9];

        Console.WriteLine("Enter 54 elements of the 6x9 matrix:");

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int max = matrix[0, 0];
        int maxRow = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                }
            }
        }

        int rowSum = 0;

        for (int j = 0; j < 9; j++)
        {
            rowSum += matrix[maxRow, j];
        }

        Console.WriteLine("Maximum element: " + max);
        Console.WriteLine("Row number: " + (maxRow + 1));
        Console.WriteLine("Sum of elements in this row: " + rowSum);
    }
}