using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter matrix size n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[,] matrix = new double[n, n];

        Console.WriteLine("Enter matrix elements:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }

        double max = matrix[0, 0];

        foreach (double element in matrix)
        {
            if (element > max)
            {
                max = element;
            }
        }

        Console.WriteLine("\nOriginal matrix:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == max)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\nResulting matrix:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }
}