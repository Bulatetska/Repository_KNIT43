using System;

int[] A =  {5, 8, 3, 8, 2, 8, 4 };

int max = A[0];
int count = 0;
int firstPosition = 0;

foreach (int number in A)
{
    if (number > max)
    {
        max = number;
    }
}

for (int i = 0; i < A.Length; i++)
{
    if (A[i] == max)
    {
        count++;

        if (count == 1)
        {
            firstPosition = i + 1;
        }
    }
}

Console.WriteLine("Максимальний елемент: " + max);
Console.WriteLine("Кількість входжень: " + count);
Console.WriteLine("Порядковий номер першого максимального елемента: " + firstPosition);