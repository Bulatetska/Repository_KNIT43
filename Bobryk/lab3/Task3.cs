using System;

double[] a = { 2.5, 3.1, 4.0, -1.0, 0.0, 0.0, 0.0, 5.5 };
int n = a.Length;

int pos = 0;
int zero = 0;

for (int i = 0; i < n - 1; i++)
{
    if (a[i] > 0 && a[i + 1] > 0)
    {
        pos++;
    }

    if (a[i] == 0 && a[i + 1] == 0)
    {
        zero++;
    }
}

Console.WriteLine("Кількість пар сусідніх додатних чисел: " + pos);
Console.WriteLine("Кількість пар сусідніх нульових елементів: " + zero);
