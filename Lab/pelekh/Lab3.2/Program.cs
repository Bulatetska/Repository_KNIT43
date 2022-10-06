static string fullPIB(string surname, string name, string patronymic)
{
    string fio = surname + " " + name + " " + patronymic;
    return fio;
}
static string shortPIB(string surname, string name, string patronymic)
{
    string fio = surname + " " + name.Substring(0, 1) + ". " + patronymic.Substring(0, 1) + ".";
    return fio;
}


string[,] FIO = {
  {"Adobe", "Samsung", "Ashanovych"},
  {"Marchuk", "Dmytro", "Grygorovych"},
  {"Patsiuk", "Alina", "Olekseevna"}
};


for (int i = 0; i < 3; i++)
{
    Console.WriteLine(fullPIB(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
    Console.WriteLine(shortPIB(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
}
Console.ReadLine();