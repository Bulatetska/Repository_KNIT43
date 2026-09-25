using System;

int[,] A =
{
    { 2, 5, 8, 1, 4, 6, 3, 7, 9 },
    { 4, 7, 2, 6, 1, 5, 8, 3, 10 },
    { 9, 3, 5, 7, 2, 4, 6, 1, 8 },
    { 1, 6, 4, 9, 3, 7, 2, 5, 11 },
    { 5, 2, 7, 3, 8, 1, 9, 4, 6 },
    { 3, 8, 1, 5, 6, 2, 4, 10, 7 }
};

int max = A[0, 0];
int maxRow = 0;

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 9; j++)
    {
        if (A[i, j] > max)
        {
            max = A[i, j];
            maxRow = i;
        }
    }
}

int sum = 0;

for (int j = 0; j < 9; j++)
{
    sum += A[maxRow, j];
}

Console.WriteLine("Найбільший елемент: " + max);
Console.WriteLine("Номер рядка: " + (maxRow + 1));
Console.WriteLine("Сума елементів рядка: " + sum);