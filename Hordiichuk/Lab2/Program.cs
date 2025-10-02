using System;

class Program
{
    static void Main()
    {
        Console.Write("Choose a task (1–6): ");
        int choice = int.Parse(Console.ReadLine()!);

        switch (choice)
        {
            case 1: Task1.Run(); break;
            case 2: Task2.Run(); break;
            case 3: Task3.Run(); break;
            case 4: Task4.Run(); break;
            case 5: Task5.Run(); break;
            case 6: Task6.Run(); break;
            default: Console.WriteLine("Wrong choice"); break;
        }
    }
}

class Task1
{
    public static void Run()
    {
        Console.Write("Enter array size n: ");
        int n = int.Parse(Console.ReadLine()!);

        int[] A = new int[n];
        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"A[{i}] = ");
            A[i] = int.Parse(Console.ReadLine()!);
        }

        int max = A[0];
        for (int i = 1; i < n; i++)
            if (A[i] > max) max = A[i];

        int count = 0;
        int firstIndex = -1;
        for (int i = 0; i < n; i++)
        {
            if (A[i] == max)
            {
                count++;
                if (firstIndex == -1) firstIndex = i + 1;
            }
        }

        Console.WriteLine($"Max element = {max}");
        Console.WriteLine($"Occurrences = {count}");
        Console.WriteLine($"First index = {firstIndex}");
    }
}

class Task2
{
    public static void Run()
    {
        Console.Write("Enter size of square matrix n: ");
        int n = int.Parse(Console.ReadLine()!);

        double[,] matrix = new double[n, n];
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                Console.Write($"[{i},{j}] = ");
                matrix[i, j] = double.Parse(Console.ReadLine()!);
            }

        double max = matrix[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] > max) max = matrix[i, j];

        Console.WriteLine("Initial matrix:");
        Print(matrix);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] == max) matrix[i, j] = 0;

        Console.WriteLine("Result matrix:");
        Print(matrix);
    }

    private static void Print(double[,] m)
    {
        int n = m.GetLength(0), mLen = m.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < mLen; j++)
                Console.Write(m[i, j] + "\t");
            Console.WriteLine();
        }
    }
}

class Task3
{
    public static void Run()
    {
        Console.Write("Enter size n: ");
        int n = int.Parse(Console.ReadLine()!);

        double[] arr = new double[n];
        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            arr[i] = double.Parse(Console.ReadLine()!);
        }

        int positivePairs = 0, zeroPairs = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] > 0 && arr[i + 1] > 0) positivePairs++;
            if (arr[i] == 0 && arr[i + 1] == 0) zeroPairs++;
        }

        Console.WriteLine($"Positive pairs = {positivePairs}");
        Console.WriteLine($"Zero pairs = {zeroPairs}");
    }
}

class Task4
{
    public static void Run()
    {
        Console.Write("Enter n (rows): ");
        int n = int.Parse(Console.ReadLine()!);
        Console.Write("Enter m (cols): ");
        int m = int.Parse(Console.ReadLine()!);

        int[,] matrix = new int[n, m];
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}] = ");
                matrix[i, j] = int.Parse(Console.ReadLine()!);
            }

        double sum = 0;
        foreach (int val in matrix) sum += val;
        double avg = sum / (n * m);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                matrix[i, j] = matrix[i, j] < avg ? -1 : 1;

        Console.WriteLine("Result matrix:");
        Print(matrix);
    }

    private static void Print(int[,] m)
    {
        int n = m.GetLength(0), mLen = m.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < mLen; j++)
                Console.Write(m[i, j] + "\t");
            Console.WriteLine();
        }
    }
}

class Task5
{
    public static void Run()
    {
        int n = 6, m = 9;
        int[,] matrix = new int[n, m];

        Console.WriteLine("Enter matrix 6x9:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}] = ");
                matrix[i, j] = int.Parse(Console.ReadLine()!);
            }

        int max = matrix[0, 0], maxRow = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                }

        int sum = 0;
        for (int j = 0; j < m; j++)
            sum += matrix[maxRow, j];

        Console.WriteLine($"Max element = {max}, row = {maxRow + 1}");
        Console.WriteLine($"Sum of that row = {sum}");
    }
}

class Task6
{
    public static void Run()
    {
        Console.Write("Enter array size n: ");
        int n = int.Parse(Console.ReadLine()!);

        double[] arr = new double[n];
        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"[{i}] = ");
            arr[i] = double.Parse(Console.ReadLine()!);
        }

        double sum = 0;
        foreach (double x in arr) sum += x;

        Console.WriteLine($"Sum of array = {sum}");
    }
}
