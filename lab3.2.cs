using System;
class Program
{
     static string FullFio(string surname, string name, string patronymic)
	{
    	string fio = surname + " " + name + " " + patronymic;
    	return fio;
	}
	static string Fio(string surname, string name, string patronymic)
	{
    	string fio = surname + " " + name.Substring(0, 1) + ". " + patronymic.Substring(0, 1) + ".";
    	return fio;
	}
	static void Main()
    	{
	string[,] FIO = {
  	{"Shevchyk", "Mukola", "Ashanovych"},
  	{"Marchuk", "Vlad", "Grygorovych"},
  	{"Pastushok", "Alina", "Olekseevna"}
	};


	for (int i = 0; i < 3; i++)
	{
    	Console.WriteLine(FullFio(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
    	Console.WriteLine(Fio(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
	}
	Console.ReadLine();
    	}
}   
