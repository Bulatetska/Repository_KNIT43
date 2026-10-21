using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Лабораторна робота 3. Масиви, колекції та цикл foreach");
            Console.WriteLine("1. Максимум масиву: кількість і перша позиція");
            Console.WriteLine("2. Замінити максимальні елементи матриці нулями");
            Console.WriteLine("3. Порахувати сусідні додатні та нульові елементи");
            Console.WriteLine("4. Порівняти елементи матриці із середнім значенням");
            Console.WriteLine("5. Сума рядка з найбільшим елементом матриці 6 x 9");
            Console.WriteLine("6. Сума дійсних елементів одновимірного масиву");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "5": Task5(); break;
                case "6": Task6(); break;
                case "0": return;
                default: Console.WriteLine("Невідомий пункт меню. Спробуйте ще раз."); break;
            }
        }
    }

    static void Task1()
    {
        int n = ReadPositiveInt("Кількість елементів n: ");
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
            numbers[i] = ReadInt($"A[{i + 1}]: ");

        int maximum = numbers[0];
        foreach (int value in numbers)
            if (value > maximum)
                maximum = value;

        int count = 0;
        foreach (int value in numbers)
            if (value == maximum)
                count++;

        int firstPosition = 1;
        for (int i = 0; i < numbers.Length; i++)
            if (numbers[i] == maximum)
            {
                firstPosition = i + 1;
                break;
            }

        Console.WriteLine($"Масив: {string.Join(" ", numbers)}");
        Console.WriteLine($"Максимальний елемент: {maximum}");
        Console.WriteLine($"Кількість входжень максимуму: {count}");
        Console.WriteLine($"Порядковий номер першого максимуму: {firstPosition}");
    }

    static void Task2()
    {
        int n = ReadPositiveInt("Порядок квадратної матриці n: ");
        double[,] matrix = ReadDoubleMatrix(n, n);
        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        double maximum = double.NegativeInfinity;
        foreach (double value in matrix)
            if (value > maximum)
                maximum = value;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] == maximum)
                    matrix[i, j] = 0;

        Console.WriteLine($"Максимальний елемент: {maximum}");
        Console.WriteLine("Матриця після заміни всіх максимумів нулями:");
        PrintMatrix(matrix);
    }

    static void Task3()
    {
        int n = ReadPositiveInt("Кількість елементів послідовності n: ");
        List<double> a = new List<double>();
        for (int i = 0; i < n; i++)
            a.Add(ReadDouble($"a[{i + 1}]: "));

        int positivePairs = 0;
        int zeroPairs = 0;
        for (int i = 1; i < a.Count; i++)
        {
            if (a[i - 1] > 0 && a[i] > 0)
                positivePairs++;
            if (a[i - 1] == 0 && a[i] == 0)
                zeroPairs++;
        }

        Console.WriteLine($"Послідовність: {string.Join(" ", a)}");
        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нульових елементів: {zeroPairs}");
    }

    static void Task4()
    {
        int n = ReadPositiveInt("Кількість рядків n: ");
        int m = ReadPositiveInt("Кількість стовпців m: ");
        int[,] matrix = ReadIntMatrix(n, m);
        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        long sum = 0;
        foreach (int value in matrix)
            sum += value;
        double average = (double)sum / matrix.Length;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < average)
                    matrix[i, j] = -1;
                else if (matrix[i, j] > average)
                    matrix[i, j] = 1;
            }

        Console.WriteLine($"Середнє арифметичне елементів: {average:0.##}");
        Console.WriteLine("Результуюча матриця (рівні середньому не змінюються):");
        PrintMatrix(matrix);
    }

    static void Task5()
    {
        int[,] matrix =
        {
            { 3, 5, 7, 2, 9, 1, 4, 8, 6 },
            { 6, 2, 1, 7, 3, 8, 5, 4, 9 },
            { 2, 3, 5, 6, 4, 99, 7, 1, 8 },
            { 9, 8, 6, 4, 2, 3, 1, 5, 7 },
            { 5, 7, 8, 1, 6, 4, 2, 9, 3 },
            { 4, 1, 2, 8, 5, 7, 9, 3, 6 }
        };

        Console.WriteLine("Задана матриця 6 x 9:");
        PrintMatrix(matrix);

        int maximum = matrix[0, 0];
        int rowIndex = 0;
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
                if (matrix[i, j] > maximum)
                {
                    maximum = matrix[i, j];
                    rowIndex = i;
                }

        int sum = 0;
        for (int j = 0; j < 9; j++)
            sum += matrix[rowIndex, j];

        Console.WriteLine($"Найбільший елемент: {maximum}");
        Console.WriteLine($"Номер рядка з найбільшим елементом: {rowIndex + 1}");
        Console.WriteLine($"Сума елементів цього рядка: {sum}");
    }

    static void Task6()
    {
        int n = ReadPositiveInt("Кількість елементів n: ");
        double[] numbers = new double[n];
        for (int i = 0; i < n; i++)
            numbers[i] = ReadDouble($"A[{i + 1}]: ");

        double sum = 0;
        foreach (double value in numbers)
            sum += value;

        Console.WriteLine($"Масив: {string.Join(" ", numbers)}");
        Console.WriteLine($"Сума елементів масиву: {sum:0.########}");
    }

    static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            int result = ReadInt(prompt);
            if (result > 0)
                return result;
            Console.WriteLine("Введіть ціле число більше нуля.");
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("Помилка: потрібно ввести ціле число.");
        }
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double result)
                && !double.IsInfinity(result) && !double.IsNaN(result))
                return result;
            Console.WriteLine("Помилка: введіть дійсне число (наприклад 2,5 або 2.5).");
        }
    }

    static int[,] ReadIntMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                matrix[i, j] = ReadInt($"A[{i + 1},{j + 1}]: ");
        return matrix;
    }

    static double[,] ReadDoubleMatrix(int rows, int columns)
    {
        double[,] matrix = new double[rows, columns];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                matrix[i, j] = ReadDouble($"A[{i + 1},{j + 1}]: ");
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j],7}");
            Console.WriteLine();
        }
    }

    static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j],9:0.##}");
            Console.WriteLine();
        }
    }
}
