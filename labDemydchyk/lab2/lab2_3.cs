using System;

double[] A = { 2.5, 4.3, 0, 0, -2.1, 5.6, 3.2, 0, 0 };

int positivePairs = 0;
int zeroPairs = 0;

for (int i = 0; i < A.Length - 1; i++)
{
    if (A[i] > 0 && A[i + 1] > 0)
    {
        positivePairs++;
    }

    if (A[i] == 0 && A[i + 1] == 0)
    {
        zeroPairs++;
    }
}

Console.WriteLine("Кількість сусідств двох додатних чисел: " + positivePairs);
Console.WriteLine("Кількість сусідств двох нульових елементів: " + zeroPairs);