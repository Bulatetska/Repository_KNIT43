using System;

int[] a = { 4, 7, 2, 7, 1, 7 };
int n = a.Length;

int max = a[0];
int count = 1;
int first = 0;

for (int i = 1; i < n; i++)
{
    if (a[i] > max)
    {
        max = a[i];
        count = 1;
        first = i;
    }
    else if (a[i] == max)
    {
        count++;
    }
}

Console.WriteLine("Максимальний елемент: " + max);
Console.WriteLine("Кількість повторень: " + count);
Console.WriteLine("Номер першого максимального елемента: " + (first + 1));
