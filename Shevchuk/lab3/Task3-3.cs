using System;

class Task3_3
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Завдання 3 ---");

        // Задана послідовність дійсних чисел
        double[] a = { 3.2, 4.5, -2.1, 0.0, 0.0, 5.6, 7.8, 9.1, 0.0, 0.0, -1.5 };

        Console.Write("Задана послідовність a: ");
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"{a[i]} ");
        }
        Console.WriteLine();

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0)
            {
                positivePairs++;
            }

            if (a[i] == 0.0 && a[i + 1] == 0.0)
            {
                zeroPairs++;
            }
        }

        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нульових елементів: {zeroPairs}");
    }
}