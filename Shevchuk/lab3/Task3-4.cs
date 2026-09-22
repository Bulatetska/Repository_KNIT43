using System;

class Task3_4
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 4 ---");

        // Задана прямокутна матриця цілих чисел 3x5
        int[,] matrix = {
            { 10,  5, 20, 15,  8 },
            {  3, 12, 25,  6, 14 },
            { 18,  2,  9, 11, 22 }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix, rows, cols);

        // Обчислення суми та середнього арифметичного
        long sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += matrix[i, j];
            }
        }

        double average = (double)sum / (rows * cols);
        Console.WriteLine($"\nСереднє арифметичне значень матриці: {average:F2}");

        // Заміна значень
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < average)
                {
                    matrix[i, j] = -1;
                }
                else if (matrix[i, j] > average)
                {
                    matrix[i, j] = 1;
                }
            }
        }

        Console.WriteLine("\nРезультуюча матриця (елементи < сер. замінено на -1, > сер. на 1):");
        PrintMatrix(matrix, rows, cols);
    }

    private static void PrintMatrix(int[,] m, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{m[i, j],4} ");
            }
            Console.WriteLine();
        }
    }
}