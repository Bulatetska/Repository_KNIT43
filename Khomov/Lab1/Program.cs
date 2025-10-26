using System;

// *** //

Console.WriteLine("1. Напишіть програму, яка обчислює середнє арифметичне двох чисел.");

Console.WriteLine("Введіть перше число:");
double num1 = double.Parse(Console.ReadLine());

Console.WriteLine("Введіть друге число:");
double num2 = double.Parse(Console.ReadLine());

Console.WriteLine("Середнє арифметичне: " + (num1 + num2) / 2);

// *** //

Console.WriteLine("\n");
Console.WriteLine("2. Виведіть на екран наступний текст: ...");
Console.WriteLine("""
To be or not to be
\ Shakespeare \
""");

// *** //

Console.WriteLine("\n");
Console.WriteLine("3. Напишіть програму, яка перевіряє число, введене з клавіатури на парність.");
double number = double.Parse(Console.ReadLine());
Console.WriteLine(number % 2 == 0 ? "Чисно парне" : "Число непарне");

// *** //

Console.WriteLine("\n");
Console.WriteLine("4. Дано натуральне число а (a <100). Напишіть програму, що виводить на екран кількість цифр в цьому числі і суму цих цифр");
int count = 0, sum = 0;
Console.WriteLine("Введіть число a:");
int a = int.Parse(Console.ReadLine());
for (int i = 0; a > 0; i++) {
    sum += a % 10;
    a /= 10;
    count++;
}
Console.WriteLine("Кількість цифр в числі a: " + count);
Console.WriteLine("Сума цифр в числі a: " + sum);

// *** //

Console.WriteLine("\n");
Console.WriteLine("5. Користувач вводить з клавіатури число, необхідно перевернути його (число) і вивести на екран.");
int flippedNum = 0;
Console.WriteLine("Введіть число:");
int num = int.Parse(Console.ReadLine());

for (int i = 0; num > 0; i++) {
    int lastDigit = num % 10;
    flippedNum = flippedNum * 10 + lastDigit;
    num /= 10;
}
Console.WriteLine(flippedNum);

// *** //

Console.WriteLine("\n");
Console.WriteLine("6. Користувач вводить з клавіатури число, необхідно показати на екран суму його цифр.");
int summa = 0;
Console.WriteLine("Введіть число:");
int keyNum = int.Parse(Console.ReadLine());
for (int i = 0; keyNum > 0; i++) {
    summa += keyNum % 10;
    keyNum /= 10;
}
Console.WriteLine("Сумма цифр = " + summa);