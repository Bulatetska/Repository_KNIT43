// 1. Напишіть програму, яка обчислює середнє арифметичне двох чисел.
Console.WriteLine("1. Середнє арифметичне");
{
    Console.Write("Введіть перше число: ");
    var a = double.Parse(Console.ReadLine());
    Console.Write("Введіть друге число: ");
    var b = double.Parse(Console.ReadLine());
    Console.WriteLine("Середнє арифметичне двох чисел: {0}", (a + b) / 2);
}

// 2. Виведіть на екран наступний текст:
// To be or not to be
// \ Shakespeare \ 
Console.WriteLine("\n2. Текст");
Console.WriteLine("""
To be or not to be
\ Shakespeare \
""");

// 3. Напишіть програму, яка перевіряє число, введене з клавіатури на парність.
Console.WriteLine("\n3. Парність");
{
    Console.Write("Введіть число: ");
    var a = double.Parse(Console.ReadLine());
    Console.WriteLine("Число {0}є парним", a % 2 == 0 ? "" : "не ");
}

// 4. Дано натуральне число а (a <100). Напишіть програму, що виводить на екран кількість цифр в цьому числі і суму цих цифр
Console.WriteLine("\n4. Кількість та сума цифр");
{
    Console.Write("Введіть число: ");
    var a = int.Parse(Console.ReadLine());
    int count = 0;
    int sum = 0;
    do {
        count += 1;
        int digit = a % 10;
        sum += digit;
        a /= 10;
    } while (a > 0);
    Console.WriteLine("Число має {0} {1} та їх сума рівна {2}", count, count == 1 ? "цифру" : (count <= 4 ? "цифри" : "цифр"), sum);
}

// 5. Користувач вводить з клавіатури число, необхідно перевернути його (число) і вивести на екран.
// Примітка: Наприклад, користувач ввів число 12345. На екрані має з'явитися число навпаки - 54321.
Console.WriteLine("\n5. Переворот числа");
{
    Console.Write("Введіть число: ");
    var a = long.Parse(Console.ReadLine());
    bool neg = a < 0;
    a = Math.Abs(a);
    long b = 0;
    while (a > 0) {
        b = b * 10 + a % 10;
        a /= 10;
    };
    if (neg) b *= -1;
    Console.WriteLine("Перевернуте число: {0}", b);
}

// 6. Користувач вводить з клавіатури число, необхідно показати на екран суму його цифр.
// Примітка: Наприклад, користувач ввів число 12345. На екрані має з'явитися повідомлення про те, що сума цифр числа 15.
Console.WriteLine("\n6. Сума цифр");
{
    Console.Write("Введіть число: ");
    var a = int.Parse(Console.ReadLine());
    a = Math.Abs(a);
    int sum = 0;
    do
    {
        int digit = a % 10;
        sum += digit;
        a /= 10;
    } while (a > 0);
    Console.WriteLine("Сума цифр числа рівна {0}", sum);
}
