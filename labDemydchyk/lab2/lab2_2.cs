using System;

double[,] A =
{
    { 2.5, 7.1, 3.2 },
    { 4.8, 7.1, 1.5 },
    { 6.3, 2.4, 5.9 }
};

double max = A[0, 0];

foreach (double number in A)
{
    if (number > max)
    {
        max = number;
    }
}

Console.WriteLine("Початкова матриця:");

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(A[i, j] + " ");
    }

    Console.WriteLine();
}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (A[i, j] == max)
        {
            A[i, j] = 0;
        }
    }
}

Console.WriteLine("Результуюча матриця:");

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(A[i, j] + " ");
    }

    Console.WriteLine();
}