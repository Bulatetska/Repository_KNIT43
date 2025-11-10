// Лабораторна робота №2 (завдання 1-6)

using System;

class Program
{
    static void Main()
    {
// Вправа 1
// 1. Задати одновимірний масив цілих чисел A[і], де і =1,2,…,n. Визначити та вивести на екран, скільки разів максимальний елемент зустрічається у даному масиві та порядковий номер першого найбільшого елементу. 
        Console.WriteLine("****** Вправа 1 ******");
        int[] A = { 4, 8, 3, 2, 6, 9, 1 };

        int max = A[0];
        for (int i = 1; i < A.Length; i++)
            if (A[i] > max) max = A[i];

        int count = 0;
        int firstIndex = -1;

        // рахую скільки разів значення max зустрічається, та знаходимо перше входження.
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == max)
            {
                count++;
                if (firstIndex == -1) firstIndex = i + 1; // порядковий номер
            }
        }

        Console.WriteLine($"Максимум = {max}");
        Console.WriteLine($"Зустрічається {count} разів");
        Console.WriteLine($"Перший номер: {firstIndex}");
        Console.WriteLine("-----------------------------\n");

// Вправа 2
// 2. Задати квадратну дійсну матрицю порядку n. Усі максимальні елементи матриці замінити нулями. Задану матрицю та результуючу вивести на екран. 
        Console.WriteLine("****** Вправа 2 ******");
        int[,] M = { { 4, 8, 3 }, { 2, 9, 6 }, { 5, 7, 3 } };

        int max2 = M[0, 0];

        // проходжу по всіх елементах матриці шоб знайти максимальне значення.
        // GetLength(0) кількість рядків GetLength(1) — кількість стовпців.
        for (int i = 0; i < M.GetLength(0); i++)
            for (int j = 0; j < M.GetLength(1); j++)
                if (M[i, j] > max2) max2 = M[i, j];

        // заміна максимальних елементів на 0
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                if (M[i, j] == max2) M[i, j] = 0;
                Console.Write(M[i, j] + "\t"); // виводжу елемента з табуляцією
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------------\n");

// Вправа 3
// Задати послідовність дійсних чисел a1, a2, …, an. Визначити в цій послідовності кількість сусідств: 
// 1) двох додатних чисел; 
// 2) двох нульових елементів. 
// Вивести на екран відповідні повідомлення. 
        Console.WriteLine("****** Вправа 3 ******");
       

        int posPairs = 0, zeroPairs = 0;

        for (int i = 0; i < seq.Length - 1; i++)
        {
            if (seq[i] > 0 && seq[i + 1] > 0) posPairs++;
            if (seq[i] == 0 && seq[i + 1] == 0) zeroPairs++;
        }

        Console.WriteLine($"Два додатних поспіль: {posPairs}");
        Console.WriteLine($"Два нулі поспіль: {zeroPairs}");
        Console.WriteLine("-----------------------------\n");

// Вправа 4
// 4. Задати цілочисельну прямокутну матрицю порядку n х m. Усі елементи матриці, менші за середнє арифметичне її значень, замінити на "-1", а більші - на "1". 
        Console.WriteLine( "***** Вправа 4 ******");
        int[,] M2 = { { 4, 8, 3, 6 }, { 2, 9, 5, 7 } };

        // обчислюю суму всіх елементів матриці
        int sumAll = 0;
        int total = M2.GetLength(0) * M2.GetLength(1); // загальна кількість елементів

        for (int i = 0; i < M2.GetLength(0); i++)
            for (int j = 0; j < M2.GetLength(1); j++)
                sumAll += M2[i, j];

        // середнє арифметичне як double для точності.
        double avg = (double)sumAll / total;

        for (int i = 0; i < M2.GetLength(0); i++)
        {
            for (int j = 0; j < M2.GetLength(1); j++)
            {
                if (M2[i, j] < avg) M2[i, j] = -1;
                else if (M2[i, j] > avg) M2[i, j] = 1;

                Console.Write(M2[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------------\n");

// Вправа 5
// 5. Задати матрицю розмірністю 6 х 9 та знайти суму елементів рядка, що містить найбільший елемент. Вважається, що такий елемент в матриці єдиний. 
        Console.WriteLine("****** Вправа 5 ******");
        int[,] M3 = new int[6, 9];

        // генератор чисел
        Random r = new Random();
        // заповнюємо матрицю випадковими числами від 1 до 99 Next верхня межа не включається.
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
                M3[i, j] = r.Next(1, 100);

        // Ініціалізуємо max3 та індексу рядка, який містить максимальний елемент.
        int max3 = M3[0, 0];
        int rowIndex = 0;

        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
                if (M3[i, j] > max3)
                {
                    max3 = M3[i, j];
                    rowIndex = i;
                }

        int sumRow = 0;
        for (int j = 0; j < 9; j++) sumRow += M3[rowIndex, j];

        Console.WriteLine($"Найбільший елемент = {max3}");
        Console.WriteLine($"Рядок {rowIndex + 1}, сума = {sumRow}");
        Console.WriteLine("-----------------------------\n");

// Вправа 6 
// 6. Задати одновимірний масив розміністю n, елементамми якого є дійсні числа. Знайти суму елементів.
        Console.WriteLine(" ****** Вправа 6 ******");
        double[] arr = { 1.8, 3.3, -5.2, 5.9 };

        double sumArr = 0;
        for (int i = 0; i < arr.Length; i++)
            sumArr += arr[i];

        Console.WriteLine($"Сума = {sumArr}");
        Console.WriteLine("-----------------------------\n");
    }
}
