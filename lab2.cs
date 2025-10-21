using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== ЗАВДАННЯ 1 ===");
        Console.Write("Введіть розмір масиву n: ");
        int n1 = int.Parse(Console.ReadLine());
        int[] A = new int[n1];
        Random rand = new Random();

        Console.WriteLine("Масив:");
        for (int i = 0; i < n1; i++)
        {
            A[i] = rand.Next(-10, 11); 
            Console.Write(A[i] + " ");
        }
        Console.WriteLine();

        int max = A[0];
        int indexMax = 0;
        for (int i = 1; i < n1; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                indexMax = i;
            }
        }

        int countMax = 0;
        foreach (int x in A)
            if (x == max) countMax++;

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Кількість повторень: {countMax}");
        Console.WriteLine($"Порядковий номер першого максимального: {indexMax + 1}");

     
        Console.WriteLine("\n=== ЗАВДАННЯ 2 ===");
        Console.Write("Введіть порядок квадратної матриці n: ");
        int n2 = int.Parse(Console.ReadLine());
        double[,] M = new double[n2, n2];

        Console.WriteLine("Початкова матриця:");
        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                M[i, j] = Math.Round(rand.NextDouble() * 20 - 10, 2); 
                Console.Write($"{M[i, j],8}");
            }
            Console.WriteLine();
        }

        
        double maxM = M[0, 0];
        for (int i = 0; i < n2; i++)
            for (int j = 0; j < n2; j++)
                if (M[i, j] > maxM) maxM = M[i, j];

        
        for (int i = 0; i < n2; i++)
            for (int j = 0; j < n2; j++)
                if (M[i, j] == maxM) M[i, j] = 0;

        Console.WriteLine("\nМатриця після заміни максимальних елементів нулями:");
        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
                Console.Write($"{M[i, j],8}");
            Console.WriteLine();
        }

        

        Console.WriteLine("\n=== ЗАВДАННЯ 3 ===");
        Console.Write("Введіть кількість елементів послідовності n: ");
        int n3 = int.Parse(Console.ReadLine());
        double[] seq = new double[n3];
        Console.WriteLine("Послідовність:");
        for (int i = 0; i < n3; i++)
        {
            seq[i] = Math.Round(rand.NextDouble() * 10 - 5, 2);
            Console.Write(seq[i] + " ");
        }
        Console.WriteLine();

        int countPosPairs = 0;
        int countZeroPairs = 0;
        for (int i = 0; i < n3 - 1; i++)
        {
            if (seq[i] > 0 && seq[i + 1] > 0) countPosPairs++;
            if (seq[i] == 0 && seq[i + 1] == 0) countZeroPairs++;
        }

        Console.WriteLine($"Кількість сусідств двох додатних: {countPosPairs}");
        Console.WriteLine($"Кількість сусідств двох нулів: {countZeroPairs}");

       


        Console.WriteLine("\n=== ЗАВДАННЯ 4 ===");
        Console.Write("Введіть n (рядки): ");
        int n4 = int.Parse(Console.ReadLine());
        Console.Write("Введіть m (стовпці): ");
        int m4 = int.Parse(Console.ReadLine());
        int[,] B = new int[n4, m4];

        Console.WriteLine("Початкова матриця:");
        int sum = 0;
        for (int i = 0; i < n4; i++)
        {
            for (int j = 0; j < m4; j++)
            {
                B[i, j] = rand.Next(0, 21); 
                sum += B[i, j];
                Console.Write($"{B[i, j],4}");
            }
            Console.WriteLine();
        }

        double avg = (double)sum / (n4 * m4);

        Console.WriteLine($"\nСереднє арифметичне: {avg:F2}");

        Console.WriteLine("\nМатриця після заміни:");
        for (int i = 0; i < n4; i++)
        {
            for (int j = 0; j < m4; j++)
            {
                if (B[i, j] < avg) B[i, j] = -1;
                else if (B[i, j] > avg) B[i, j] = 1;
                else B[i, j] = 0;
                Console.Write($"{B[i, j],4}");
            }
            Console.WriteLine();
        }

        


        Console.WriteLine("\n=== ЗАВДАННЯ 5 ===");
        int[,] C = new int[6, 9];
        Console.WriteLine("Матриця 6x9:");
        int maxC = int.MinValue;
        int rowOfMax = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                C[i, j] = rand.Next(-50, 51);
                Console.Write($"{C[i, j],4}");
                if (C[i, j] > maxC)
                {
                    maxC = C[i, j];
                    rowOfMax = i;
                }
            }
            Console.WriteLine();
        }

        int sumRow = 0;
        for (int j = 0; j < 9; j++)
            sumRow += C[rowOfMax, j];

        Console.WriteLine($"\nНайбільший елемент: {maxC}");
        Console.WriteLine($"Рядок з найбільшим елементом: {rowOfMax + 1}");
        Console.WriteLine($"Сума елементів цього рядка: {sumRow}");

        

        Console.WriteLine("\n=== ЗАВДАННЯ 6 ===");
        Console.Write("Введіть розмір масиву n: ");
        int n6 = int.Parse(Console.ReadLine());
        double[] arr6 = new double[n6];
        double sum6 = 0;
        Console.WriteLine("Масив:");
        for (int i = 0; i < n6; i++)
        {
            arr6[i] = Math.Round(rand.NextDouble() * 20 - 10, 2);
            Console.Write(arr6[i] + " ");
            sum6 += arr6[i];
        }
        Console.WriteLine($"\nСума елементів масиву: {sum6:F2}");

     
    }
}