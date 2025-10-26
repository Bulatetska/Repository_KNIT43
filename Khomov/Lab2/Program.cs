using System;

// *** //

Console.WriteLine("1. Задати одновимірний масив цілих чисел A[і], де і =1,2,…,n. Визначити та вивести на екран, скільки разів максимальний елемент зустрічається у даному масиві та порядковий номер першого найбільшого елементу.");

Console.Write("Введіть розмір масиву: ");
int nArray = int.Parse(Console.ReadLine());

int[] A = new int[nArray];

Console.WriteLine("Введіть елементи масиву:");
for (int i = 0; i < nArray; i++) {
    Console.Write($"A[{i}] = ");
    A[i] = int.Parse(Console.ReadLine());
}

int max = A[0];
for (int i = 1; i < nArray; i++) {
    if (A[i] > max)
    max = A[i];
}

int count = 0;
int firstIndex = -1;
for (int i = 0; i < nArray; i++) {
    if (A[i] == max) {
        count++;
        if (firstIndex == -1) {
            firstIndex = i;
        }
    }
}

Console.WriteLine("Максимальний елемент: " + max);
Console.WriteLine("Кількість його повторень: " + count);
Console.WriteLine("Порядковий номер першого входження: " + firstIndex);

// *** //

Console.WriteLine("\n");
Console.WriteLine("2. Задати квадратну дійсну матрицю порядку n. Усі максимальні елементи матриці замінити нулями. Задану матрицю та результуючу вивести на екран.");

Console.Write("Введіть порядок квадратної матриці n: ");
int nMatrix = int.Parse(Console.ReadLine());

double[,] matrix = new double[nMatrix, nMatrix];

Console.WriteLine("Введіть елементи матриці:");
for (int i = 0; i < nMatrix; i++) {
    for (int j = 0; j < nMatrix; j++) {
        Console.Write($"matrix[{i},{j}] = ");
        matrix[i, j] = double.Parse(Console.ReadLine());
    }
}

Console.WriteLine("Задана матриця:");
for (int i = 0; i < nMatrix; i++) {
    for (int j = 0; j < nMatrix; j++) {
        Console.Write(matrix[i, j] + "\t");
    }
    Console.WriteLine();
}

// Максимальний елемент матриці.
double maxMatrix = matrix[0, 0];
for (int i = 0; i < nMatrix; i++) {
    for (int j = 0; j < nMatrix; j++) {
        if (matrix[i, j] > maxMatrix) {
            maxMatrix = matrix[i, j];
        }
    }
}

// Заміна всіх максимальних елементів на 0.
for (int i = 0; i < nMatrix; i++) {
    for (int j = 0; j < nMatrix; j++) {
        if (matrix[i, j] == maxMatrix) {
            matrix[i, j] = 0;
        }
    }
}

Console.WriteLine("\nРезультуюча матриця:");
for (int i = 0; i < nMatrix; i++) {
    for (int j = 0; j < nMatrix; j++) {
        Console.Write(matrix[i, j] + "\t");
    }
    Console.WriteLine();
}

// *** //

Console.WriteLine("\n");
Console.WriteLine("3. Задати послідовність дійсних чисел a1, a2, …, an. Визначити в цій послідовності кількість сусідств: 1) двох додатних чисел; 2) двох нульових елементів. Вивести на екран відповідні повідомлення.");

Console.Write("Введіть кількість елементів послідовності: ");
int nSeq = int.Parse(Console.ReadLine());

double[] seq = new double[nSeq];

Console.WriteLine("Введіть елементи послідовності:");
for (int i = 0; i < nSeq; i++) {
    Console.Write($"seq[{i}] = ");
    seq[i] = double.Parse(Console.ReadLine());
}

int positivePairs = 0;
int zeroPairs = 0;

for (int i = 0; i < nSeq - 1; i++) {
    if (seq[i] > 0 && seq[i + 1] > 0) {
        positivePairs++;
    }

    if (seq[i] == 0 && seq[i + 1] == 0) {
        zeroPairs++;
    }
}

Console.WriteLine("Кількість сусідств додатніх чисел: " + positivePairs);
Console.WriteLine("Кількість сусідств нульових елементів: " + zeroPairs);

// *** //

Console.WriteLine("\n");
Console.WriteLine("4. Задати цілочисельну прямокутну матрицю порядку n х m. Усі елементи матриці, менші за середнє арифметичне її значень, замінити на \"-1\", а більші - на \"1\".");

Console.Write("Введіть кількість рядків n: ");
int nRect = int.Parse(Console.ReadLine());

Console.Write("Введіть кількість стовпців m: ");
int mRect = int.Parse(Console.ReadLine());

int[,] rectMatrix = new int[nRect, mRect];

Console.WriteLine("Введіть елементи матриці:");
for (int i = 0; i < nRect; i++) {
    for (int j = 0; j < mRect; j++) {
        Console.Write($"rectMatrix[{i},{j}] = ");
        rectMatrix[i, j] = int.Parse(Console.ReadLine());
    }
}

// Обчислення середнього арифметичного.
double sum = 0;
for (int i = 0; i < nRect; i++) {
    for (int j = 0; j < mRect; j++) {
        sum += rectMatrix[i, j];
    }
}

double average = sum / (nRect * mRect);
Console.WriteLine("\nСереднє арифметичне: " + average);

// Заміна елементів на -1 або 1.
int[,] resultMatrix = new int[nRect, mRect];
for (int i = 0; i < nRect; i++) {
    for (int j = 0; j < mRect; j++) {
        if (rectMatrix[i, j] < average)
            resultMatrix[i, j] = -1;
        else if (rectMatrix[i, j] > average)
            resultMatrix[i, j] = 1;
        else
            resultMatrix[i, j] = rectMatrix[i, j];;
    }
}

Console.WriteLine("Результуюча матриця:");
for (int i = 0; i < nRect; i++) {
    for (int j = 0; j < mRect; j++) {
        Console.Write(resultMatrix[i, j] + "\t");
    }
    Console.WriteLine();
}

// *** //

Console.WriteLine("\n");
Console.WriteLine("5. Задати матрицю розмірністю 6 х 9 та знайти суму елементів рядка, що містить найбільший елемент. Вважається, що такий елемент в матриці єдиний.");

int nRows = 6;
int nCols = 9;

int[,] matrix6x9 = new int[nRows, nCols];

Console.WriteLine("Введіть елементи матриці:");
for (int i = 0; i < nRows; i++) {
    for (int j = 0; j < nCols; j++) {
        Console.Write($"matrix[{i},{j}] = ");
        matrix6x9[i, j] = int.Parse(Console.ReadLine());
    }
}

// Знаходження максимального елемента, та його рядка.
int maxElement = matrix6x9[0, 0];
int maxRowIndex = 0;

for (int i = 0; i < nRows; i++) {
    for (int j = 0; j < nCols; j++) {
        if (matrix6x9[i, j] > maxElement) {
            maxElement = matrix6x9[i, j];
            maxRowIndex = i;
        }
    }
}

int sumRow = 0;
for (int j = 0; j < nCols; j++) {
    sumRow += matrix6x9[maxRowIndex, j];
}

Console.WriteLine("Найбільший елемент матриці: " + maxElement);
Console.WriteLine("Індекс рядка з найбільшим елементом: " + maxRowIndex);
Console.WriteLine("Сума елементів цього рядка: " + sumRow);

// *** //

Console.WriteLine("\n");
Console.WriteLine("6. Задати одновимірний масив розміністю n, елементамми якого є дійсні числа. Знайти суму елементів.");

Console.Write("Введіть розмір масиву: ");
int nArray6 = int.Parse(Console.ReadLine());

double[] array6 = new double[nArray6];

Console.WriteLine("Введіть елементи масиву:");
for (int i = 0; i < nArray6; i++) {
    Console.Write($"array6[{i}] = ");
    array6[i] = double.Parse(Console.ReadLine());
}

double sum6 = 0;
for (int i = 0; i < nArray6; i++) {
    sum6 += array6[i];
}

Console.WriteLine("Сума елементів масиву: " + sum6);