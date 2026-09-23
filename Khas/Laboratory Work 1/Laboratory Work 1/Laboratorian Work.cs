// Task 1
Console.WriteLine("Завдання 1");
Console.Write("Введіть перше число: ");
double a = double.Parse(Console.ReadLine());
Console.Write("Введіть друге число: ");
double b = double.Parse(Console.ReadLine());

double average = (a + b) / 2;
Console.WriteLine($"Середнє арифметичне: {average}");

// Task 2
Console.WriteLine("Завдання 2");
Console.WriteLine("To be or not to be");
Console.WriteLine("\\ Shakespeare \\");

// Task 3
Console.WriteLine("Завдання 3");
Console.Write("Введіть число: ");
int n = int.Parse(Console.ReadLine());

if (n % 2 == 0)
    Console.WriteLine($"{n} — парне число");
else
    Console.WriteLine($"{n} — непарне число");

// Task 4
Console.WriteLine("Завдання 4");
Console.Write("Введіть число (менше 100): ");
int c = int.Parse(Console.ReadLine());

int count = 0;
int sum_1 = 0;
int temp_1 = c;

while (temp_1 > 0)
{
    sum_1 += temp_1 % 10;
    temp_1 /= 10;
    count++;
}

Console.WriteLine($"Кількість цифр: {count}");
Console.WriteLine($"Сума цифр: {sum_1}");

// Task 5
Console.WriteLine("Завдання 5");
Console.Write("Введіть число: ");
int m = int.Parse(Console.ReadLine());

int reversed = 0;
int temp_2 = m;

while (temp_2 > 0)
{
    int digit = temp_2 % 10;
    reversed = reversed * 10 + digit;
    temp_2 /= 10;
}

Console.WriteLine($"Перевернуте число: {reversed}");

// Task 6
Console.WriteLine("Завдання 6");

int sum_2 = 0;
int temp_3 = m;

while (temp_3 > 0)
{
    sum_2 += temp_3 % 10;
    temp_3 /= 10;
}

Console.WriteLine($"Сума цифр числа {m} дорівнює {sum_2}.");