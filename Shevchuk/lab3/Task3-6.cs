using System;

class Task3_6
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 6 ---");

        // Заданий одновимірний масив дійсних чисел
        double[] arr = { 10.5, 4.25, -3.1, 7.8, 12.0, 0.45, -5.9, 8.1 };

        Console.Write("Заданий масив дійсних чисел: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();

        // Обчислення суми елементів
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        Console.WriteLine($"Сума елементів масиву: {sum:F2}");
    }
}