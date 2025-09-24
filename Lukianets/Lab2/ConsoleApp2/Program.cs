using System;
using System.Linq; // для зручних методів роботи з масивами

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    // 1. Одновимірний масив: кількість максимальних елементів і перший індекс
    static void Task1()
    {
        Console.WriteLine("=== Завдання 1 ===");
        int[] A = { 3, 7, 2, 7, 5, 7 }; // приклад

        int max = A.Max();
        int count = 0;
        foreach (int x in A)
        {
            if (x == max)
                count++;
        }

        int firstIndex = Array.IndexOf(A, max) + 1;

        Console.WriteLine("Масив: " + string.Join(", ", A));
        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Кількість входжень: {count}");
        Console.WriteLine($"Перший порядковий номер: {firstIndex}\n");
    }

    // 2. Квадратна матриця: замінити всі максимальні елементи на 0
    static void Task2()
    {
        Console.WriteLine("=== Завдання 2 ===");
        double[,] matrix =
        {
            { 1, 5, 3 },
            { 7, 5, 7 },
            { 2, 4, 7 }
        };

        double max = double.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > max)
                    max = matrix[i, j];

        double[,] result = (double[,])matrix.Clone();
        for (int i = 0; i < result.GetLength(0); i++)
            for (int j = 0; j < result.GetLength(1); j++)
                if (result[i, j] == max)
                    result[i, j] = 0;

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);
        Console.WriteLine("Результуюча матриця:");
        PrintMatrix(result);
        Console.WriteLine();
    }

    // 3. Послідовність: кількість сусідств
    static void Task3()
    {
        Console.WriteLine("=== Завдання 3 ===");
        double[] seq = { 1, 2, 0, 0, -3, 4, 5, 0, 0, 0, 6 };

        int positivePairs = 0, zeroPairs = 0;
        for (int i = 0; i < seq.Length - 1; i++)
        {
            if (seq[i] > 0 && seq[i + 1] > 0) positivePairs++;
            if (seq[i] == 0 && seq[i + 1] == 0) zeroPairs++;
        }

        Console.WriteLine("Послідовність: " + string.Join(", ", seq));
        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нулів: {zeroPairs}\n");
    }

    // 4. Прямокутна матриця: замінити < середнього → -1, > середнього → 1
    static void Task4()
    {
        Console.WriteLine("=== Завдання 4 ===");
        int[,] matrix =
        {
            { 3, 8, 6 },
            { 1, 5, 9 }
        };

        double sum = 0;
        int count = 0;

        foreach (int x in matrix)
        {
            sum += x;
            count++;
        }

        double avg = sum / count;


        int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < avg) result[i, j] = -1;
                else if (matrix[i, j] > avg) result[i, j] = 1;
                else result[i, j] = 0;
            }

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);
        Console.WriteLine($"Середнє арифметичне: {avg:F2}");
        Console.WriteLine("Результуюча матриця:");
        PrintMatrix(result);
        Console.WriteLine();
    }

    // 5. Матриця 6x9: знайти суму елементів рядка, де є найбільший елемент
    static void Task5()
    {
        Console.WriteLine("=== Завдання 5 ===");
        int[,] matrix =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
            { 11, 22, 33, 44, 55, 66, 77, 88, 99 },
            { 5, 10, 15, 20, 25, 30, 35, 40, 45 },
            { 100, 90, 80, 70, 60, 50, 40, 30, 20 },
            { 7, 14, 21, 28, 35, 42, 49, 56, 63 }
        };

        int maxVal = int.MinValue, maxRow = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxRow = i;
                }
            }
        }

        int sumRow = 0;
        for (int j = 0; j < 9; j++)
            sumRow += matrix[maxRow, j];

        Console.WriteLine("Матриця 6x9:");
        PrintMatrix(matrix);
        Console.WriteLine($"\nНайбільший елемент: {maxVal}");
        Console.WriteLine($"Він знаходиться у рядку № {maxRow + 1}");
        Console.WriteLine($"Сума елементів цього рядка: {sumRow}\n");
    }

    // 6. Масив дійсних чисел: знайти суму елементів
    static void Task6()
    {
        Console.WriteLine("=== Завдання 6 ===");
        double[] arr = { 1.5, 2.3, -4.1, 5.7, 3.3 };

        double sum = arr.Sum();
        Console.WriteLine("Масив: " + string.Join(", ", arr));
        Console.WriteLine($"Сума елементів масиву = {sum}\n");
    }

    // Допоміжний метод для друку матриці
    static void PrintMatrix<T>(T[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j].ToString().PadLeft(6));
            Console.WriteLine();
        }
    }
}
