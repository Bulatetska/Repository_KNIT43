using System;

class Task3_1
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 1 ---");

        // Заданий масив цілих чисел
        int[] A = { 12, 45, 8, 45, 23, 45, 17, 30 };

        Console.Write("Заданий масив A: ");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"{A[i]} ");
        }
        Console.WriteLine();

        // 1. Пошук максимуму та його першого порядкового номера
        int max = A[0];
        int firstIndex = 0;

        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                firstIndex = i;
            }
        }

        // 2. Підрахунок входжень
        int count = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == max)
            {
                count++;
            }
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Порядковий номер першого найбільшого елементу: {firstIndex + 1} (індекс {firstIndex})");
        Console.WriteLine($"Кількість входжень у масив: {count}");
    }
}