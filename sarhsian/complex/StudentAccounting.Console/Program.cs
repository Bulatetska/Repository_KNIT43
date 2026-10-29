using System.Globalization;
using System.Text;
using StudentAccounting.Core;

Console.OutputEncoding = Encoding.UTF8;
var manager = new StudentManager();
var files = new StudentFileService();

if (File.Exists(files.JsonPath))
{
    try
    {
        manager.ReplaceAll(files.Load());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Не вдалося завантажити файл: {ex.Message}");
        manager.ReplaceAll(StudentManager.SampleStudents());
    }
}
else
{
    manager.ReplaceAll(StudentManager.SampleStudents());
}

while (true)
{
    Console.WriteLine("\nОблік студентів");
    Console.WriteLine("1. Список студентів");
    Console.WriteLine("2. Додати студента");
    Console.WriteLine("3. LINQ: успішність групи");
    Console.WriteLine("4. Записати у текстовий файл");
    Console.WriteLine("5. Зберегти (JSON)");
    Console.WriteLine("6. Завантажити (JSON)");
    Console.WriteLine("0. Вихід");
    Console.Write("Оберіть пункт: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            PrintStudents(manager.Students);
            break;
        case "2":
            Console.Write("Ім'я студента: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            int age = ReadInt("Вік: ", 1, 120);
            double mark = ReadDouble("Середній бал (0-100): ", 0, 100);
            try
            {
                var student = new Student { Name = name, Age = age, AverageMark = mark };
                manager.Add(student);
                Console.WriteLine($"Студента додано. {manager.AgeMessage(student)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "3":
            Console.WriteLine("Студенти з середнім балом від 80 (за спаданням):");
            PrintStudents(manager.HighPerformers());
            Console.WriteLine("Вся група за середнім балом (за спаданням):");
            PrintStudents(manager.SortedByMark());
            Console.WriteLine($"Середній бал групи: {manager.GroupAverage():0.##}");
            break;
        case "4":
            files.ExportText(manager);
            Console.WriteLine($"Дані записано: {files.TextPath}");
            break;
        case "5":
            files.Save(manager.Students);
            Console.WriteLine($"Дані збережено: {files.JsonPath}");
            break;
        case "6":
            try
            {
                manager.ReplaceAll(files.Load());
                Console.WriteLine($"Дані завантажено: {files.JsonPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не вдалося завантажити: {ex.Message}");
            }
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Невідомий пункт меню.");
            break;
    }
}

static void PrintStudents(IEnumerable<Student> students)
{
    var items = students.ToList();
    if (items.Count == 0)
    {
        Console.WriteLine("Список порожній.");
        return;
    }

    foreach (var s in items)
    {
        string status = s.Age < 18 ? "Студент неповнолітній" : "Студент повнолітній";
        Console.WriteLine($"{s.Name}, {s.Age} років, бал {s.AverageMark:0.##}. {status}");
    }
}

static int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            return value;
        Console.WriteLine($"Введіть ціле число від {min} до {max}.");
    }
}

static double ReadDouble(string prompt, double min, double max)
{
    while (true)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
        if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture,
                out double value) && !double.IsNaN(value) && value >= min && value <= max)
            return value;
        Console.WriteLine($"Введіть число від {min} до {max}.");
    }
}
