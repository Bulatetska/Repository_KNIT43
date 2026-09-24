Console.Write("Введіть число: ");
int number = Convert.ToInt32(Console.ReadLine());

int sum = 0;

// Обчислення суми цифр
while (number > 0)
{
    int digit = number % 10;
    sum += digit;
    number /= 10;
}

// Виведення результату
Console.WriteLine("Сума цифр числа: " + sum);

