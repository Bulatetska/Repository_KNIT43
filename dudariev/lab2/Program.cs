// 1.Задати одновимірний масив цілих чисел A[і], де і = 1,2,…, n.
// Визначити та вивести на екран, скільки разів максимальний елемент
// зустрічається у даному масиві та порядковий номер першого найбільшого елементу. 
{
    Console.WriteLine("\n1.");
    int[] A = { 3, 7, 4, 9, 6, 3, 6, 9, 4, 1, 2, 9 };
    int maxVal = A[0];
    int maxIdx = 0;
    int maxCnt = 1;
    for (int i = 1; i < A.Length; i++)
    {
        if (A[i] > maxVal)
        {
            maxVal = A[i];
            maxIdx = i;
            maxCnt = 1;
        }
        else if (A[i] == maxVal)
        {
            maxCnt += 1;
        }
    }
    Console.WriteLine("Max Value: {0}", maxVal);
    Console.WriteLine("First Index: {0}", maxIdx);
    Console.WriteLine("Count: {0}", maxCnt);
}

// 2. Задати квадратну дійсну матрицю порядку n.
// Усі максимальні елементи матриці замінити нулями.
// Задану матрицю та результуючу вивести на екран.
{
    Console.WriteLine("\n2.");

    void PrintMat(double[,] A)
    {
        Console.WriteLine("A = {");
        for (int row = 0; row < A.GetLength(0); row++)
        {
            Console.Write("  { ");
            for (int col = 0; col < A.GetLength(1); col++)
            {
                if (col != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0,3}", A[row, col]);
            }
            Console.WriteLine("},");
        }
        Console.WriteLine("}");
    }

    int n = 4;
    double[,] A = {
        { 3, 5.5, 1, -1 },
        { 6, 7, 0, -3 },
        { 7, 1, 1, 3 },
        { 1.1, 7, 2.2, 7 },
    };

    // Print initial matrix
    PrintMat(A);

    // Find max value
    double maxVal = double.NegativeInfinity;
    foreach (var val in A)
    {
        maxVal = Math.Max(maxVal, val);
    }

    // Replace max value with 0
    for (int row = 0; row < A.GetLength(0); row++)
    {
        for (int col = 0; col < A.GetLength(1); col++)
        {
            if (A[row, col] == maxVal)
            {
                A[row, col] = 0;
            }
        }
    }

    // Print new matrix
    PrintMat(A);
}

// 3. Задати послідовність дійсних чисел a1, a2, …, an.
// Визначити в цій послідовності кількість сусідств:
// 1) двох додатних чисел;
// 2) двох нульових елементів.
// Вивести на екран відповідні повідомлення.
{
    Console.WriteLine("\n3.");

    double[] A = { 1, 5, -1, 0, 0, -1, -2, 4, 2, 6, 0, -2, 5 };

    int posPairs = 0;
    int zeroPairs = 0;

    for (int i = 0; i < A.Length - 1; i++)
    {
        var curr = A[i];
        var next = A[i + 1];
        if (curr > 0 && next > 0)
        {
            posPairs += 1;
        }
        if (curr == 00 && next == 0)
        {
            zeroPairs += 1;
        }
    }

    Console.WriteLine("Positive pair count: {0}", posPairs);
    Console.WriteLine("Zero pair count: {0}", zeroPairs);
}

// 4. Задати цілочисельну прямокутну матрицю порядку n х m.
// Усі елементи матриці, менші за середнє арифметичне її значень, замінити на "-1", а більші - на "1". 
{
    Console.WriteLine("\n4.");

    void PrintMat(int[,] A)
    {
        Console.WriteLine("A = {");
        for (int row = 0; row < A.GetLength(0); row++)
        {
            Console.Write("  { ");
            for (int col = 0; col < A.GetLength(1); col++)
            {
                if (col != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0,3}", A[row, col]);
            }
            Console.WriteLine("},");
        }
        Console.WriteLine("}");
    }

    int[,] A =
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
    };

    PrintMat(A);

    int sum = 0;
    foreach (var val in A)
    {
        sum += val;
    }
    int belowAvg = (sum - 1) / A.Length;
    int aboveAvg = sum / A.Length + 1;

    Console.WriteLine("Avg = {0}", (double)sum / A.Length);

    for (int row = 0; row < A.GetLength(0); row++)
    {
        for (int col = 0; col < A.GetLength(1); col++)
        {
            if (A[row, col] <= belowAvg)
            {
                A[row, col] = -1;
            } else if (A[row, col] >= aboveAvg)
            {
                A[row, col] = 1;
            }
        }
    }

    PrintMat(A);
}

// 5. Задати матрицю розмірністю 6 х 9 та знайти суму елементів рядка, що містить найбільший елемент.
// Вважається, що такий елемент в матриці єдиний. 
{
    Console.WriteLine("\n5.");

    int[,] A =
    {
        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 2, 3, 4, 5, 6, 7, 8, 9, 0 },
        { 5, 2, 8, 5, 3, 7, 9, 5, 1 },
        { 1, 2, 6, 4, 9, 6, 4, 2, 1 },
        { 1, 6, 5, 2, 10, 1, 5, 8, 0 },
        { 1, 2, 0, 2, 1, 7, 4, 2, 9 },
    };

    var maxVal = int.MinValue;
    int maxRow = 0;
    for (int row = 0; row < A.GetLength(0); row++)
    {
        for (int col = 0; col < A.GetLength(1); col++)
        {
            if (A[row, col] > maxVal)
            {
                maxVal = A[row, col];
                maxRow = row;
            }
        }
    }

    Console.WriteLine("Max value = {0} on row {1}", maxVal, maxRow);

    int sum = 0;
    for (int col = 0; col < A.GetLength(1); col++)
    {
        sum += A[maxRow, col];
    }

    Console.WriteLine("Sum = {0}", sum);
}

// 6. Задати одновимірний масив розміністю n, елементамми якого є дійсні числа.
// Знайти суму елементів.
{
    Console.WriteLine("\n6.");

    double[] A = { -2, 5.2, 3, 8, -4, 2.2, 9, 0, -1, 1 };

    double sum = 0;
    foreach (var val in A)
    {
        sum += val;
    }

    Console.WriteLine("Sum = {0}", sum);
}