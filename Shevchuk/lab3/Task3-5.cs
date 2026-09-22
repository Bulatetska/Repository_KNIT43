using System;

class Task3_5
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 5 ---");

        // Задана матриця 6x9 (найбільший елемент 99.5 розташований у 3-му рядку з індексом 2)
        double[,] matrix = {
            {  1.2,  3.4,  5.1,  2.0,  0.5,  4.1,  6.2,  1.1,  2.3 },
            {  7.1,  8.0,  2.2,  1.5,  3.3,  5.5,  4.4,  2.8,  0.9 },
            { 10.5, 12.1,  4.2, 99.5,  6.7,  8.1,  3.0, 11.2,  5.4 },
            {  4.5,  6.1,  7.2,  3.3,  2.1,  1.0,  0.8,  5.9,  4.2 },
            {  8.2,  1.1,  0.4,  5.6,  7.7,  2.3,  9.0,  3.1,  6.5 },
            {  2.5,  3.8,  1.9,  4.0,  5.1,  6.6,  7.3,  8.4,  9.2 }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        Console.WriteLine("Задана матриця 6x9:");
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Рядок {i + 1}: ");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],6:F1} ");
            }
            Console.WriteLine();
        }

        // Пошук найбільшого елемента та індексу його рядка
        double maxElement = matrix[0, 0];
        int maxRowIndex = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                    maxRowIndex = i;
                }
            }
        }

        // Обчислення суми елементів відповідного рядка
        double rowSum = 0;
        for (int j = 0; j < cols; j++)
        {
            rowSum += matrix[maxRowIndex, j];
        }

        Console.WriteLine($"\nНайбільший елемент: {maxElement} (знаходиться у рядку {maxRowIndex + 1})");
        Console.WriteLine($"Сума елементів рядка {maxRowIndex + 1}: {rowSum:F2}");
    }
}