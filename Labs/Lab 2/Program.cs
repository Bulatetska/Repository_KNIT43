using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ЛАБОРАТОРНОЇ ===");
            Console.WriteLine("1. Масив: скільки разів зустрічається максимум і номер першого максимуму");
            Console.WriteLine("2. Матриця: замінити всі максимальні елементи на 0");
            Console.WriteLine("3. Послідовність: сусідства (++) та (0,0)");
            Console.WriteLine("4. Прямокутна матриця: елементи < середнього -> -1, > середнього -> 1");
            Console.WriteLine("5. Матриця 6x9: сума рядка з найбільшим елементом");
            Console.WriteLine("6. Масив дійсний: сума елементів");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Помилка вводу. Спробуйте ще раз.");
                continue;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 0:
                    Console.WriteLine("Вихід з програми...");
                    return;
                default:
                    Console.WriteLine("Невірний пункт меню, спробуйте ще раз.");
                    break;
            }
        }
    }

    // 1. Одновимірний масив: скільки разів максимум і номер першого максимуму
    static void Task1()
    {
        Console.Write("Введіть розмір масиву n: ");
        int n = int.Parse(Console.ReadLine());

        int[] A = new int[n];

        Console.WriteLine("Введіть елементи масиву A:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"A[{i + 1}] = ");
            A[i] = int.Parse(Console.ReadLine());
        }

        int max = A[0];
        for (int i = 1; i < n; i++)
            if (A[i] > max)
                max = A[i];

        int countMax = 0;
        int firstIndex = -1; // 1-based
        for (int i = 0; i < n; i++)
        {
            if (A[i] == max)
            {
                countMax++;
                if (firstIndex == -1)
                    firstIndex = i + 1; // порядковий номер (з 1)
            }
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Кількість входжень максимального елемента: {countMax}");
        Console.WriteLine($"Порядковий номер першого максимуму: {firstIndex}");
    }

    // 2. Квадратна дійсна матриця, замінити всі максимальні елементи на 0
    static void Task2()
    {
        Console.Write("Введіть порядок квадратної матриці n: ");
        int n = int.Parse(Console.ReadLine());

        double[,] M = new double[n, n];

        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"M[{i},{j}] = ");
                M[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочаткова матриця:");
        PrintMatrix(M);

        // знаходимо максимум
        double max = M[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] > max)
                    max = M[i, j];

        // створюємо результуючу матрицю
        double[,] R = new double[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                R[i, j] = (M[i, j] == max) ? 0.0 : M[i, j];

        Console.WriteLine($"\nМаксимальний елемент матриці: {max}");
        Console.WriteLine("Результуюча матриця (максимальні елементи замінені на 0):");
        PrintMatrix(R);
    }

    // 3. Кількість сусідств (++ і 0,0) у послідовності
    static void Task3()
    {
        Console.Write("Введіть кількість елементів послідовності n: ");
        int n = int.Parse(Console.ReadLine());

        double[] a = new double[n];

        Console.WriteLine("Введіть елементи послідовності:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i + 1}] = ");
            a[i] = double.Parse(Console.ReadLine());
        }

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0)
                positivePairs++;

            if (a[i] == 0 && a[i + 1] == 0)
                zeroPairs++;
        }

        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість сусідств двох нульових елементів: {zeroPairs}");
    }

    // 4. Прямокутна матриця n x m: елементи < avg -> -1, > avg -> 1
    static void Task4()
    {
        Console.Write("Введіть кількість рядків n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців m: ");
        int m = int.Parse(Console.ReadLine());

        int[,] A = new int[n, m];

        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"A[{i},{j}] = ");
                A[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // знаходимо середнє арифметичне
        long sum = 0;
        int count = n * m;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                sum += A[i, j];

        double avg = (double)sum / count;

        Console.WriteLine($"\nСереднє арифметичне елементів: {avg}");

        Console.WriteLine("\nПочаткова матриця:");
        PrintMatrix(A);

        // змінюємо матрицю по правилу
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                if (A[i, j] < avg)
                    A[i, j] = -1;
                else if (A[i, j] > avg)
                    A[i, j] = 1;
                // якщо A[i,j] == avg – залишаємо як є
            }

        Console.WriteLine("\nРезультуюча матриця:");
        PrintMatrix(A);
    }

    // 5. Матриця 6 x 9: сума рядка з найбільшим елементом
    static void Task5()
    {
        int rows = 6;
        int cols = 9;
        int[,] M = new int[rows, cols];

        Console.WriteLine("Введіть елементи матриці 6 x 9:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"M[{i},{j}] = ");
                M[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nМатриця:");
        PrintMatrix(M);

        int max = M[0, 0];
        int maxRow = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (M[i, j] > max)
                {
                    max = M[i, j];
                    maxRow = i;
                }
            }
        }

        int rowSum = 0;
        for (int j = 0; j < cols; j++)
            rowSum += M[maxRow, j];

        Console.WriteLine($"\nНайбільший елемент: {max}, знаходиться в рядку {maxRow}.");
        Console.WriteLine($"Сума елементів цього рядка: {rowSum}");
    }

    // 6. Одновимірний масив дійсних чисел: сума елементів
    static void Task6()
    {
        Console.Write("Введіть розмір масиву n: ");
        int n = int.Parse(Console.ReadLine());

        double[] a = new double[n];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i + 1}] = ");
            a[i] = double.Parse(Console.ReadLine());
        }

        double sum = 0;
        for (int i = 0; i < n; i++)
            sum += a[i];

        Console.WriteLine($"Сума елементів масиву: {sum}");
    }

    // Допоміжні методи для виводу матриць
    static void PrintMatrix(double[,] M)
    {
        int n = M.GetLength(0);
        int m = M.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(M[i, j] + "\t");
            Console.WriteLine();
        }
    }

    static void PrintMatrix(int[,] M)
    {
        int n = M.GetLength(0);
        int m = M.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(M[i, j] + "\t");
            Console.WriteLine();
        }
    }
}
