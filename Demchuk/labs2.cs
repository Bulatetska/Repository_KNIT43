using System;
class Task1
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
      /task1
        Console.Write("Введіть розмір масиву n: ");
        int n = int.Parse(Console.ReadLine());
        int[] A = new int[n];
        Console.WriteLine("Введіть елементи масиву через Enter:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"A[{i + 1}] = ");
            A[i] = int.Parse(Console.ReadLine());
        }
        int max = A[0];
        int count = 1;
        int firstOrderNumber = 1;
        for (int i = 1; i < n; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                count = 1;
                firstOrderNumber = i + 1;
            }
            else if (A[i] == max)
            {
                count++;
            }
        }
        Console.WriteLine("\n- Результат роботи програми -");
        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Кількість входжень максимуму: {count}");
        Console.WriteLine($"Порядковий номер першого входження: {firstOrderNumber}");
    }
}

/task2
        Console.Write("Введіть порядок квадратної матриці n: ");
        int n = int.Parse(Console.ReadLine());
        double[,] matrix = new double[n, n];
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matrix[{i},{j}] = ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("\n- Початкова матриця -");
        PrintMatrix(matrix, n, n);
        double max = matrix[0, 0];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        Console.WriteLine($"\nМаксимальний елемент: {max}");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == max)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\n- Результуюча матриця -");
        PrintMatrix(matrix, n, n);
    }
    static void PrintMatrix(double[,] m, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{m[i, j],7:F2} ");
            }
            Console.WriteLine();
        }
    }
}

/task3 
        Console.Write("Введіть кількість чисел n (n >= 2): ");
        int n = int.Parse(Console.ReadLine());
        if (n < 2)
        {
            Console.WriteLine("Для визначення сусідств потрібно хоча б 2 елементи!");
            return;
        }
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
            {
                positivePairs++;
            }
            if (a[i] == 0 && a[i + 1] == 0)
            {
                zeroPairs++;
            }
        }

        Console.WriteLine("\n- Результати аналізу пар -");
        Console.WriteLine($"1) Кількість сусідств двох додатних чисел: {positivePairs}");
        Console.WriteLine($"2) Кількість сусідств двох нульових елементів: {zeroPairs}");
    }
}

/task4
        Console.Write("Введіть кількість рядків n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців m: ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        Console.WriteLine("Введіть цілочисельні елементи матриці:");
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"matrix[{i},{j}] = ");
                matrix[i, j] = int.Parse(Console.ReadLine());
                sum += matrix[i, j];
            }
        }

        double average = (double)sum / (n * m);
        Console.WriteLine("\n- Початкова матриця -");
        PrintIntMatrix(matrix, n, m);
        Console.WriteLine($"\nСума елементів: {sum}");
        Console.WriteLine($"Середнє арифметичне: {average:F3}");
        Console.WriteLine("Примітка: елементи, що строго дорівнюють середньому арифметичному, залишаються без змін.");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < average)
                {
                    matrix[i, j] = -1;
                }
                else if (matrix[i, j] > average)
                {
                    matrix[i, j] = 1;
                }
            }
        }
        Console.WriteLine("\n- Результуюча матриця -");
        PrintIntMatrix(matrix, n, m);
    }
    static void PrintIntMatrix(int[,] m, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{m[i, j],5} ");
            }
            Console.WriteLine();
        }
    }
}

/task5
        const int rows = 6;
        const int cols = 9;
        int[,] matrix = new int[rows, cols];
        Random rnd = new Random();    
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(1, 100);
            }
        }
        Console.WriteLine("- Згенерована матриця 6x9 -");
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Рядок {i + 1}: ");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],4} ");
            }
            Console.WriteLine();
        }
        int max = matrix[0, 0];
        int maxRowIndex = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRowIndex = i;
                }
            }
        }        
        int rowSum = 0;
        for (int j = 0; j < cols; j++)
        {
            rowSum += matrix[maxRowIndex, j];
        }
        Console.WriteLine("\n- Результат -");
        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Знаходиться у рядку №: {maxRowIndex + 1} (індекс {maxRowIndex})");
        Console.WriteLine($"Сума елементів цього рядка: {rowSum}");
    }
}

/task6
        Console.Write("Введіть розмірність одновимірного масиву n: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i + 1}] = ");
            arr[i] = double.Parse(Console.ReadLine());
        }
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }
        Console.WriteLine("\n- Результат -");
        Console.WriteLine($"Сума всіх {n} елементів масиву = {sum:F2}");
    }
}
