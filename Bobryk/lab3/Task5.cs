using System;

int[,] a =
{
    { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
    { 10, 20, 99, 30, 40, 50, 60, 70, 80 },
    { 3, 6, 9, 12, 15, 18, 21, 24, 27 },
    { 2, 4, 6, 8, 10, 12, 14, 16, 18 },
    { 5, 10, 15, 20, 25, 30, 35, 40, 45 }
};

int max = a[0, 0];
int row = 0;

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 9; j++)
    {
        if (a[i, j] > max)
        {
            max = a[i, j];
            row = i;
        }
    }
}

long sum = 0;

for (int j = 0; j < 9; j++)
{
    sum += a[row, j];
}

Console.WriteLine("Найбільший елемент: " + max);
Console.WriteLine("Номер рядка: " + (row + 1));
Console.WriteLine("Сума елементів цього рядка: " + sum);
