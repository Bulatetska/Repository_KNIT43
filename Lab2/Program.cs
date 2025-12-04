using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ЗАВДАНЬ ===");
            Console.WriteLine("1. Масив: максимум і кількість появ");
            Console.WriteLine("2. Матриця: замінити максимальні елементи нулями");
            Console.WriteLine("3. Послідовність: сусідства додатних і нулів");
            Console.WriteLine("4. Матриця: заміна елементів на -1 і 1 відносно середнього");
            Console.WriteLine("5. Матриця 6x9: сума рядка з найбільшим елементом");
            Console.WriteLine("6. Масив: сума елементів");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");
            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 0: return;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }
    }

    // 1. Масив: скільки разів максимум і його перший індекс
    static void Task1()
    {
        int[] A = { 3, 7, 2, 7, 4, 7, 1 };
        int max = A[0];
        foreach (var x in A) if (x > max) max = x;

        int count = 0, firstIndex = -1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == max)
            {
                count++;
                if (firstIndex == -1) firstIndex = i + 1;
            }
        }

        Console.WriteLine($"\nМаксимальний елемент: {max}");
        Console.WriteLine($"Кількість появ: {count}");
        Console.WriteLine($"Перший номер: {firstIndex}");
    }

    // 2. Квадратна матриця: замінити всі максимальні елементи на 0
    static void Task2()
    {
        double[,] M = {
            { 1.2, 4.5, 3.3 },
            { 4.5, 2.2, 4.5 },
            { 0.9, 4.5, 1.1 }
        };

        int n = M.GetLength(0);
        double max = M[0, 0];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] > max) max = M[i, j];

        Console.WriteLine("\nПочаткова матриця:");
        Print(M);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] == max) M[i, j] = 0;

        Console.WriteLine("\nРезультуюча матриця:");
        Print(M);
    }

    // 3. Послідовність: кількість сусідств
    static void Task3()
    {
        double[] a = { 0, 1.5, 2.3, 0, 0, -3.1, 0, 4.5, 6.7 };

        int positivePairs = 0, zeroPairs = 0;

        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0) positivePairs++;
            if (a[i] == 0 && a[i + 1] == 0) zeroPairs++;
        }

        Console.WriteLine($"\nКількість сусідств двох додатних: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нулів: {zeroPairs}");
    }

    // 4. Прямокутна матриця: замінити елементи на -1 і 1
    static void Task4()
    {
        int[,] A = {
            { 2, 5, 7 },
            { 1, 3, 9 },
            { 4, 6, 8 }
        };

        int n = A.GetLength(0);
        int m = A.GetLength(1);
        double sum = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                sum += A[i, j];

        double avg = sum / (n * m);

        Console.WriteLine($"\nСереднє арифметичне: {avg:F2}");
        Console.WriteLine("Результуюча матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (A[i, j] < avg) A[i, j] = -1;
                else if (A[i, j] > avg) A[i, j] = 1;
                Console.Write($"{A[i, j],3}");
            }
            Console.WriteLine();
        }
    }

    // 5. Матриця 6x9: сума рядка з найбільшим елементом
    static void Task5()
    {
        int[,] M = new int[6, 9];
        Random rnd = new Random();

        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
                M[i, j] = rnd.Next(1, 100);

        int max = M[0, 0];
        int rowIndex = 0;

        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
                if (M[i, j] > max)
                {
                    max = M[i, j];
                    rowIndex = i;
                }

        int sum = 0;
        for (int j = 0; j < 9; j++)
            sum += M[rowIndex, j];

        Console.WriteLine($"\nНайбільший елемент: {max}");
        Console.WriteLine($"Індекс рядка: {rowIndex + 1}");
        Console.WriteLine($"Сума цього рядка: {sum}");
    }

    // 6. Сума елементів масиву
    static void Task6()
    {
        double[] arr = { 1.2, 3.4, 5.6, 7.8 };
        double sum = 0;
        foreach (double x in arr) sum += x;

        Console.WriteLine($"\nСума елементів масиву: {sum}");
    }

    static void Print(double[,] M)
    {
        int n = M.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{M[i, j],6}");
            Console.WriteLine();
        }
    }
}
