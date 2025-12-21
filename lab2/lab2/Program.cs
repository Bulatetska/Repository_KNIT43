using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Масив: кількість появ максимального елемента і його перший індекс");
            Console.WriteLine("2. Матриця: замінити всі максимальні елементи нулями");
            Console.WriteLine("3. Послідовність: кількість сусідств додатних і нульових елементів");
            Console.WriteLine("4. Матриця: заміна елементів відносно середнього значення (-1 / 1)");
            Console.WriteLine("5. Матриця 6x9: сума рядка, що містить найбільший елемент");
            Console.WriteLine("6. Масив: знайти суму елементів");
           
            Console.Write("Оберіть номер завдання: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 6)
            {
                Console.WriteLine("Некоректний вибір! Спробуйте ще раз.");
                continue;
            }

         

            Console.WriteLine();
            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
            }
        }
    }

    // 1. Масив: скільки разів зустрічається максимум і його перший індекс
    static void Task1()
    {
        Console.Write("Введіть кількість елементів масиву: ");
        int n = int.Parse(Console.ReadLine());
        int[] A = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"A[{i + 1}] = ");
            A[i] = int.Parse(Console.ReadLine());
        }

        int max = A.Max();
        int count = A.Count(x => x == max);
        int firstIndex = Array.IndexOf(A, max) + 1; // +1 — щоб рахувати з 1

        Console.WriteLine($"\nМаксимальний елемент: {max}");
        Console.WriteLine($"Кількість появ: {count}");
        Console.WriteLine($"Перший номер: {firstIndex}");
    }

    // 2. Матриця: замінити всі максимальні елементи нулями
    static void Task2()
    {
        Console.Write("Введіть розмір квадратної матриці n: ");
        int n = int.Parse(Console.ReadLine());
        double[,] M = new double[n, n];

        Console.WriteLine("\nВведіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"M[{i + 1},{j + 1}] = ");
                M[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочаткова матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{M[i, j],8}");
            Console.WriteLine();
        }

        // Знаходимо максимум
        double max = M[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] > max)
                    max = M[i, j];

        Console.WriteLine($"\nМаксимальний елемент: {max}");

        // Замінюємо всі максимальні елементи нулями
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (M[i, j] == max)
                    M[i, j] = 0;

        Console.WriteLine("\nМатриця після заміни максимумів нулями:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{M[i, j],8}");
            Console.WriteLine();
        }
    }

    // 3. Послідовність: кількість сусідств додатних і нульових
    static void Task3()
    {
        Console.Write("Введіть кількість елементів послідовності: ");
        int n = int.Parse(Console.ReadLine());
        double[] a = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i + 1}] = ");
            a[i] = double.Parse(Console.ReadLine());
        }

        int positivePairs = 0, zeroPairs = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (a[i] > 0 && a[i + 1] > 0) positivePairs++;
            if (a[i] == 0 && a[i + 1] == 0) zeroPairs++;
        }

        Console.WriteLine($"\nКількість пар двох додатних чисел: {positivePairs}");
        Console.WriteLine($"Кількість пар двох нулів: {zeroPairs}");
    }

    // 4. Матриця: менші за середнє = -1, більші = 1
    static void Task4()
    {
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців (m): ");
        int m = int.Parse(Console.ReadLine());

        int[,] M = new int[n, m];

        Console.WriteLine("\nВведіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"M[{i + 1},{j + 1}] = ");
                M[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочаткова матриця:");
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{M[i, j],5}");
                sum += M[i, j];
            }
            Console.WriteLine();
        }

        double avg = sum / (n * m);
        Console.WriteLine($"\nСереднє арифметичне значення: {avg:F2}");

        // Заміна елементів відносно середнього
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (M[i, j] < avg) M[i, j] = -1;
                else if (M[i, j] > avg) M[i, j] = 1;
                else M[i, j] = 0;
            }
        }

        Console.WriteLine("\nМатриця після заміни:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{M[i, j],5}");
            Console.WriteLine();
        }
    }

    // 5. Матриця 6x9: сума рядка з найбільшим елементом
    static void Task5()
    {
        const int rows = 6;
        const int cols = 9;
        int[,] M = new int[rows, cols];

        Console.WriteLine("Введіть елементи матриці 6x9:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"M[{i + 1},{j + 1}] = ");
                M[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочаткова матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write($"{M[i, j],5}");
            Console.WriteLine();
        }

        // Знаходимо найбільший елемент і його позицію
        int max = M[0, 0];
        int maxRow = 0, maxCol = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (M[i, j] > max)
                {
                    max = M[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }

        // Рахуємо суму елементів рядка з максимальним елементом
        int sumRow = 0;
        for (int j = 0; j < cols; j++)
            sumRow += M[maxRow, j];

        Console.WriteLine($"\nНайбільший елемент: {max} (рядок {maxRow + 1}, стовпець {maxCol + 1})");
        Console.WriteLine($"Сума елементів цього рядка = {sumRow}");
    }

    // 6. Масив: сума елементів
    static void Task6()
    {
        Console.Write("Введіть кількість елементів: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i + 1}] = ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        double sum = arr.Sum();
        Console.WriteLine($"\nСума елементів = {sum}");
    }
}
