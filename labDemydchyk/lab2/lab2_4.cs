using System;

int[,] A =
{
    { 2, 5, 8 },
    { 10, 4, 6 },
    { 3, 9, 7 }
};

int sum = 0;
int count = 0;

foreach (int number in A)
{
    sum += number;
    count++;
}

double average = (double)sum / count;

Console.WriteLine("Середнє арифметичне: " + average);

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (A[i, j] < average)
        {
            A[i, j] = -1;
        }
        else if (A[i, j] > average)
        {
            A[i, j] = 1;
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