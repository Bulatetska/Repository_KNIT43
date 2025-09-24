using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("\n--- Задача 1 ---");
        Task1();

        Console.WriteLine("\n--- Задача 2 ---");
        Task2();

        Console.WriteLine("\n--- Задача 3 ---");
        Task3();

        Console.WriteLine("\n--- Задача 4 ---");
        Task4();

        Console.WriteLine("\n--- Задача 5 ---");
        Task5();

        Console.WriteLine("\n--- Задача 6 ---");
        Task6();

    }

    static void Task1()
    {
        Console.WriteLine("Одновимірний масив: кількість входжень максимального елемента та індекс першого найбільшого.");
        Console.Write("Введіть розмір n: ");
        int n = int.Parse(Console.ReadLine());

        int[] A = new int[n];
        Console.WriteLine($"Введіть {n} цілих чисел:");
        for (int i = 0; i < n; i++)
            A[i] = int.Parse(Console.ReadLine());

        int max = A[0];
        for (int i = 1; i < n; i++)
            if (A[i] > max) max = A[i];

        int count = 0;
        int firstIndex1Based = -1;
        for (int i = 0; i < n; i++)
        {
            if (A[i] == max) count++;
            if (firstIndex1Based == -1 && A[i] == max) firstIndex1Based = i + 1;
        }

        Console.WriteLine($"\nМаксимальний елемент: {max}");
        Console.WriteLine($"Кількість входжень: {count}");
        Console.WriteLine($"Перший індекс: {firstIndex1Based}");
    }

    static void Task2()
    {
        Console.WriteLine("Квадратна матриця: замінити всі максимальні елементи на 0.");
        Console.Write("Введіть порядок n: ");
        int n = int.Parse(Console.ReadLine());

        double[,] M = new double[n, n];
        Console.WriteLine($"Введіть матрицю {n}×{n}:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                M[i, j] = double.Parse(Console.ReadLine());

        Console.WriteLine("\nЗадана матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{M[i, j],8:G6} ");
            Console.WriteLine();
        }

        double max = M[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] > max) max = M[i, j];

        double[,] R = (double[,])M.Clone();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (R[i, j] == max) R[i, j] = 0.0;

        Console.WriteLine($"\nМаксимальне значення: {max}");
        Console.WriteLine("Результат:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{R[i, j],8:G6} ");
            Console.WriteLine();
        }
    }

    static void Task3()
    {
        Console.WriteLine("Послідовність: кількість сусідств (двох додатних і двох нульових).");
        Console.Write("Введіть n (≥2): ");
        int n = int.Parse(Console.ReadLine());

        double[] a = new double[n];
        Console.WriteLine($"Введіть {n} дійсних чисел:");
        for (int i = 0; i < n; i++)
            a[i] = double.Parse(Console.ReadLine());

        int posPos = 0, zeroZero = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0) posPos++;
            if (a[i] == 0 && a[i + 1] == 0) zeroZero++;
        }

        Console.WriteLine($"\nСусідств двох додатних: {posPos}");
        Console.WriteLine($"Сусідств двох нульових: {zeroZero}");
    }

    static void Task4()
    {
        Console.WriteLine("Цілочисельна матриця n×m: ");
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть m: ");
        int m = int.Parse(Console.ReadLine());

        int[,] B = new int[n, m];
        Console.WriteLine($"Введіть матрицю {n}×{m}:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                B[i, j] = int.Parse(Console.ReadLine());

        Console.WriteLine("\nЗадана матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{B[i, j],6}");
            Console.WriteLine();
        }

        long sum = 0;
        foreach (var v in B) sum += v;
        double avg = (double)sum / (n * m);

        int[,] R = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (B[i, j] < avg) R[i, j] = -1;
                else if (B[i, j] > avg) R[i, j] = 1;
                else R[i, j] = 0;

        Console.WriteLine($"\nСереднє арифметичне: {avg:F4}");
        Console.WriteLine("Результат:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{R[i, j],6}");
            Console.WriteLine();
        }
    }

    static void Task5()
    {
        Console.WriteLine("Матриця 6×9: сума рядка, що містить найбільший елемент.");
        int n = 6, m = 9;
        double[,] M = new double[n, m];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                M[i, j] = rnd.Next(0, 16);

        Console.WriteLine("\nЗадана матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{M[i, j],6}");
            Console.WriteLine();
        }

        double max = M[0, 0];
        int maxRow = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (M[i, j] > max)
                {
                    max = M[i, j];
                    maxRow = i;
                }

        double rowSum = 0;
        for (int j = 0; j < m; j++)
            rowSum += M[maxRow, j];

        Console.WriteLine($"\nНайбільший елемент: {max} (рядок {maxRow + 1})");
        Console.WriteLine($"Сума цього рядка: {rowSum}");
    }

    static void Task6()
    {
        Console.WriteLine("Одновимірний масив дійсних: знайти суму елементів.");
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());

        double[] a = new double[n];
        Console.WriteLine($"Введіть {n} дійсних чисел:");
        for (int i = 0; i < n; i++)
            a[i] = double.Parse(Console.ReadLine());

        double sum = 0;
        for (int i = 0; i < n; i++)
            sum += a[i];

        Console.WriteLine($"\nСума елементів: {sum}");
    }
}
