using System;
static string FullName(string surname, string name, string patronymic)
{
    string fio = surname + " " + name + " " + patronymic;
    return fio;
}
static string CreateName(string surname, string name, string patronymic)
{
    string fio = surname + " " + name.Substring(0, 1) + ". " + patronymic.Substring(0, 1) + ".";
    return fio;
}
string[,] Name = {
    {"Порошенко", "Петро", "Олексійович"},
    {"Зеленський", "Володимир", "Олександрович"},
    {"Ющенко", "Віктор", "Андрійович"}
};
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(FullName(Name[i, 0], Name[i, 1], Name[i, 2]));
    Console.WriteLine(CreateName(Name[i, 0], Name[i, 1], Name[i, 2]));
}
Console.ReadLine();