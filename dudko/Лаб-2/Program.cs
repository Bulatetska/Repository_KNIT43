using System;

class Program
{
    static void Main()
    {
        // 1. Задати одновимірний масив цілих чисел
        Console.WriteLine("=== Завдання 1 ===");
        int[] A = { 3, 7, 2, 7, 5, 7, 1 };

        int max = A[0];
        for (int i = 1; i < A.Length; i++)
        if (A[i] > max) max = A[i];

        int count = 0;
        int first = -1;
        for (int i = 0; i < A.Length; i++)
     {
        if (A[i] == max)
     {
        count++;
        if (first == -1) first = i + 1; // порядковий номер
     }
   }

     Console.WriteLine("Максимум = " + max);
     Console.WriteLine("Зустрічається " + count + " раз(и)");
     Console.WriteLine("Перший номер: " + first);

        Console.WriteLine("-----------------------------\n");

        // 2. Задати квадратну дійсну матрицю порядку n.
      Console.WriteLine("=== Завдання 2 ===");
      int[,] M = { {3,7,2}, {1,7,5}, {4,6,7} };

      int max2 = M[0,0];
      for (int i = 0; i < M.GetLength(0); i++)
      for (int j = 0; j < M.GetLength(1); j++)
         if (M[i,j] > max2) max2 = M[i,j];

      for (int i = 0; i < M.GetLength(0); i++)
       {
        for (int j = 0; j < M.GetLength(1); j++)
      {
        if (M[i,j] == max2) M[i,j] = 0;
        Console.Write(M[i,j] + "\t");
     }
        Console.WriteLine();
      }

        Console.WriteLine("-----------------------------\n");


        //  3. Задати послідовність дійсних чисел a1, a2, …, an.
        Console.WriteLine("=== Завдання 3 ===");
        double[] seq = { 1,2,-3,0,0,4,5,0 };

        int pos = 0, zeros = 0;

        for (int i = 0; i < seq.Length - 1; i++)
         {
          if (seq[i] > 0 && seq[i+1] > 0) pos++;
          if (seq[i] == 0 && seq[i+1] == 0) zeros++;
         }

         Console.WriteLine("Два додатних: " + pos);
         Console.WriteLine("Два нулі: " + zeros);


        Console.WriteLine("-----------------------------\n");

        //  4. Задати цілочисельну прямокутну матрицю порядку n х m. 
        Console.WriteLine("=== Завдання 4 ===");
        int[,] M2 = { {3,7,2,5}, {1,8,4,6} };

        int sumAll = 0;
        int total = M2.GetLength(0) * M2.GetLength(1);

        for (int i = 0; i < M2.GetLength(0); i++)
        for (int j = 0; j < M2.GetLength(1); j++)
        sumAll += M2[i,j];

        double avg = (double)sumAll / total;

        for (int i = 0; i < M2.GetLength(0); i++)
        {
         for (int j = 0; j < M2.GetLength(1); j++)
        {
         if (M2[i,j] < avg) M2[i,j] = -1;
         else if (M2[i,j] > avg) M2[i,j] = 1;
         Console.Write(M2[i,j] + "\t");
        }
        Console.WriteLine();
}

        Console.WriteLine("-----------------------------\n");

        //  5. Задати матрицю розмірністю 6 х 9 та знайти суму елементів рядка, що містить найбільший елемент.
        Console.WriteLine("=== Завдання 5 ===");
        Console.WriteLine("\n=== Завдання 5 ===");
        int[,] M3 = new int[6,9];
        Random r = new Random();

        for (int i = 0; i < 6; i++)
        for (int j = 0; j < 9; j++)
        M3[i,j] = r.Next(1,100);

        int max3 = M3[0,0];
        int row = 0;

        for (int i = 0; i < 6; i++)
         for (int j = 0; j < 9; j++)
          if (M3[i,j] > max3)
         {
            max3 = M3[i,j];
            row = i;
         }

         int sumRow = 0;
         for (int j = 0; j < 9; j++) sumRow += M3[row,j];

         Console.WriteLine("Найбільший = " + max3);
         Console.WriteLine("Рядок " + (row+1) + ", сума = " + sumRow);


        Console.WriteLine("-----------------------------\n");

        // 6. Задати одновимірний масив розміністю n, елементамми якого є дійсні числа. Знайти суму елементів.
        Console.WriteLine("=== Завдання 6 ===");
        Console.WriteLine("\n=== Завдання 6 ===");
        double[] arr = { 1.5, 2.3, -4.1, 6.7 };

        double sumArr = 0;
        for (int i = 0; i < arr.Length; i++)
        sumArr += arr[i];

        Console.WriteLine("Сума = " + sumArr);

    }
    
}






