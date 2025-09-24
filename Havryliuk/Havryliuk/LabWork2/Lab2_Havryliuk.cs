using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Лабораторна робота 2. Масиви, колекції та цикл foreach");
        Console.WriteLine("Оберіть завдання (1-6) або 0 для виходу:");

        while (true)
        {
            Console.WriteLine("\n1. Кількість максимальних елементів");
            Console.WriteLine("2. Заміна максимальних елементів у матриці");
            Console.WriteLine("3. Кількість сусідств у послідовності");
            Console.WriteLine("4. Заміна елементів матриці на -1/1");
            Console.WriteLine("5. Сума рядка з найбільшим елементом");
            Console.WriteLine("6. Сума елементів масиву");
            Console.WriteLine("0. Вийти");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    // Завдання 1: Кількість максимальних елементів
    static void Task1()
    {
        Console.WriteLine("\n--- Завдання 1 ---");

        // Створюємо масив
        int[] A = { 3, 7, 2, 7, 5, 7, 1, 9, 7, 9 };
        Console.WriteLine("Масив: " + string.Join(", ", A));

        int max = A.Max();
        int count = A.Count(x => x == max);
        int firstMaxIndex = Array.IndexOf(A, max) + 1; // +1 бо індекс з 1

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Зустрічається {count} разів");
        Console.WriteLine($"Перший найбільший елемент на позиції: {firstMaxIndex}");
    }

    // Завдання 2: Заміна максимальних елементів у матриці
    static void Task2()
    {
        Console.WriteLine("\n--- Завдання 2 ---");

        // Створюємо матрицю 3x3
        double[,] matrix = {
            { 1.5, 2.8, 3.2 },
            { 4.1, 5.7, 6.3 },
            { 7.9, 8.4, 5.7 }
        };

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        // Знаходимо максимум
        double max = matrix.Cast<double>().Max();

        // Створюємо копію для результату
        double[,] result = (double[,])matrix.Clone();

        // Заміняємо максимуми на 0
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                if (result[i, j] == max)
                {
                    result[i, j] = 0;
                }
            }
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine("Результуюча матриця:");
        PrintMatrix(result);
    }

    // Завдання 3: Кількість сусідств
    static void Task3()
    {
        Console.WriteLine("\n--- Завдання 3 ---");

        double[] sequence = { 1.5, 2.8, 0, 0, -3.2, 4.1, 5.7, 0, 8.4 };
        Console.WriteLine("Послідовність: " + string.Join(", ", sequence));

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            if (sequence[i] > 0 && sequence[i + 1] > 0)
            {
                positivePairs++;
            }
            else if (sequence[i] == 0 && sequence[i + 1] == 0)
            {
                zeroPairs++;
            }
        }

        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нульових елементів: {zeroPairs}");
    }

    // Завдання 4: Заміна елементів матриці на -1/1
    static void Task4()
    {
        Console.WriteLine("\n--- Завдання 4 ---");

        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("Початкова матриця:");
        PrintIntMatrix(matrix);

        // Обчислюємо середнє арифметичне
        double average = matrix.Cast<int>().Average();
        Console.WriteLine($"Середнє арифметичне: {average:F2}");

        // Створюємо результатну матрицю
        int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < average)
                {
                    result[i, j] = -1;
                }
                else
                {
                    result[i, j] = 1;
                }
            }
        }

        Console.WriteLine("Результуюча матриця:");
        PrintIntMatrix(result);
    }

    // Завдання 5: Сума рядка з найбільшим елементом
    static void Task5()
    {
        Console.WriteLine("\n--- Завдання 5 ---");

        int[,] matrix = new int[6, 9];
        Random random = new Random();

        // Заповнюємо матрицю випадковими числами
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                matrix[i, j] = random.Next(1, 100);
            }
        }

        Console.WriteLine("Матриця 6x9:");
        PrintIntMatrix(matrix);

        // Знаходимо найбільший елемент і його рядок
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

        // Обчислюємо суму рядка
        int sum = 0;
        for (int j = 0; j < 9; j++)
        {
            sum += matrix[maxRow, j];
        }

        Console.WriteLine($"Найбільший елемент: {max} (у рядку {maxRow + 1})");
        Console.WriteLine($"Сума рядка {maxRow + 1}: {sum}");
    }

    // Завдання 6: Сума елементів масиву
    static void Task6()
    {
        Console.WriteLine("\n--- Завдання 6 ---");

        double[] array = { 1.5, 2.8, 3.2, 4.1, 5.7 };
        Console.WriteLine("Масив: " + string.Join(", ", array));

        double sum = array.Sum();
        Console.WriteLine($"Сума елементів: {sum}");
    }

    // Допоміжні методи для виводу матриць
    static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],6:F1} ");
            }
            Console.WriteLine();
        }
    }

    static void PrintIntMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
} 