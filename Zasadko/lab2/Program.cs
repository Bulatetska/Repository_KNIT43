using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть завдання:");
            Console.WriteLine("1 - Масив: максимум, кількість і позиція");
            Console.WriteLine("2 - Квадратна матриця: заміна максимумів на 0");
            Console.WriteLine("3 - Послідовність: сусідства");
            Console.WriteLine("4 - Матриця n x m: заміна на -1 та 1");
            Console.WriteLine("5 - Матриця 6 x 9: сума рядка з максимумом");
            Console.WriteLine("6 - Одновимірний масив: сума елементів");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
                continue;

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 0: return;
                default: Console.WriteLine("Невірний вибір"); break;
            }
        }
    }

    // 1. Масив: максимум, кількість і позиція
    static void Task1()
    {
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        int[] A = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"A[{i + 1}] = ");
            A[i] = int.Parse(Console.ReadLine());
        }

        int max = A[0];
        int count = 0;
        int firstIndex = 0;

        for (int i = 0; i < n; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                count = 1;
                firstIndex = i;
            }
            else if (A[i] == max)
            {
                count++;
            }
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Кількість: {count}");
        Console.WriteLine($"Порядковий номер першого: {firstIndex + 1}");
    }

    // 2. Квадратна матриця: заміна максимумів
    static void Task2()
    {
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        double[,] matrix = new double[n, n];

        Console.WriteLine("Введіть матрицю:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matrix[i, j] = double.Parse(Console.ReadLine());

        double max = matrix[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] > max)
                    max = matrix[i, j];

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] == max)
                    matrix[i, j] = 0;

        Console.WriteLine("Результуюча матриця:");
        PrintMatrix(matrix);
    }

    // 3. Сусідства
    static void Task3()
    {
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        double[] a = new double[n];

        for (int i = 0; i < n; i++)
            a[i] = double.Parse(Console.ReadLine());

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0)
                positivePairs++;

            if (a[i] == 0 && a[i + 1] == 0)
                zeroPairs++;
        }

        Console.WriteLine($"Сусідства двох додатних: {positivePairs}");
        Console.WriteLine($"Сусідства двох нульових: {zeroPairs}");
    }

    // 4. Матриця n x m
    static void Task4()
    {
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть m: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];
        double sum = 0;

        Console.WriteLine("Введіть матрицю:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
                sum += matrix[i, j];
            }

        double avg = sum / (n * m);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                matrix[i, j] = matrix[i, j] < avg ? -1 : 1;

        Console.WriteLine("Результат:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    // 5. Матриця 6 x 9
    static void Task5()
    {
        int[,] matrix = new int[6, 9];
        int max = int.MinValue;
        int maxRow = 0;

        Console.WriteLine("Введіть матрицю 6 x 9:");
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                }
            }

        int sum = 0;
        for (int j = 0; j < 9; j++)
            sum += matrix[maxRow, j];

        Console.WriteLine($"Сума елементів рядка з максимумом: {sum}");
    }

    // 6. Сума елементів масиву
    static void Task6()
    {
        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());
        double[] a = new double[n];
        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            a[i] = double.Parse(Console.ReadLine());
            sum += a[i];
        }

        Console.WriteLine($"Сума елементів масиву: {sum}");
    }

    static void PrintMatrix(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}
