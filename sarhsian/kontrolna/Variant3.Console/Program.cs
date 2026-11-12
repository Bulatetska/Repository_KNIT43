using System.Globalization;
using System.Text;
using Variant3.Core;

// Для правильного зчитування українських букв у консолі Windows.
Console.InputEncoding = new UTF8Encoding(false);
Console.OutputEncoding = new UTF8Encoding(false);

while (true)
{
    Console.WriteLine("Варіант 3");
    Console.WriteLine("1. Пошук української букви «і» у слові");
    Console.WriteLine("2. Площі квадрата та куба");
    Console.WriteLine("0. Вихід");
    Console.Write("Оберіть завдання: ");
    string? choice = Console.ReadLine();
    Console.WriteLine();

    if (choice == "0") break;

    switch (choice)
    {
        case "1":
            Console.Write("Введіть слово без пробілів: ");
            string word = Console.ReadLine() ?? "";

            try
            {
                var result = WordAnalyzer.Analyze(word);
                Console.WriteLine($"Кількість букв «і»: {result.Count}");
                if (result.Count > 0)
                    Console.WriteLine($"Позиції: {string.Join(", ", result.Positions)}");
                else if (result.HasLatinI)
                    Console.WriteLine("Українську «і» не знайдено. У слові є латинська i/I. Перемкніть розкладку на українську.");
                else
                    Console.WriteLine("Українську букву «і» не знайдено.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "2":
            double x = ReadNumber("Координата X: ");
            double y = ReadNumber("Координата Y: ");
            double side = ReadPositiveNumber("Довжина сторони: ");

            Square square = new(x, y, side);
            Cub cub = new(x, y, side);

            Console.WriteLine($"Площа квадрата: {square.Area():G}");
            Console.WriteLine($"Площа однієї грані куба: {cub.FaceArea():G}");
            Console.WriteLine($"Площа всієї поверхні куба: {cub.SurfaceArea():G}");
            break;

        default:
            Console.WriteLine("Невідомий пункт меню.");
            break;
    }

    Console.WriteLine();
}

static double ReadNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
        if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
            && double.IsFinite(value))
            return value;
        Console.WriteLine("Введіть коректне число.");
    }
}

static double ReadPositiveNumber(string prompt)
{
    while (true)
    {
        double value = ReadNumber(prompt);
        if (value > 0) return value;
        Console.WriteLine("Сторона має бути більшою за нуль.");
    }
}
