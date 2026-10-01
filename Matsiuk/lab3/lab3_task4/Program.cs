using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns m: ");
        int m = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[n, m];

        int sum = 0;

        Console.WriteLine("Enter matrix elements:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                sum += matrix[i, j];
            }
        }

        double average = (double)sum / (n * m);

        Console.WriteLine("\nArithmetic mean: " + average);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < average)
                {
                    matrix[i, j] = -1;
                }
                else if (matrix[i, j] > average)
                {
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\nResulting matrix:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }
}