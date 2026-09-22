using System;

class Task3_2
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 2 ---");

        // Задана дійсна квадратна матриця 4x4
        double[,] matrix = {
            { 1.5, 4.2, 9.8, 3.1 },
            { 9.8, 2.0, 7.4, 5.6 },
            { 0.5, 9.8, 1.2, 4.3 },
            { 8.9, 6.7, 3.4, 2.1 }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        Console.WriteLine("Задана матриця:");
        PrintMatrix(matrix, rows, cols);

        // Пошук максимуму
        double max = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }

        // Заміна максимальних елементів на 0
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == max)
                {
                    matrix[i, j] = 0.0;
                }
            }
        }

        Console.WriteLine($"\nМаксимальний елемент ({max}) замінено нулями.");
        Console.WriteLine("Результуюча матриця:");
        PrintMatrix(matrix, rows, cols);
    }

    private static void PrintMatrix(double[,] m, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{m[i, j],6:F1} ");
            }
            Console.WriteLine();
        }
    }
}