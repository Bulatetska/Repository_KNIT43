using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private class Hero
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Comics { get; set; }
    }


    private static readonly List<Hero> _heroes = new List<Hero>
    {
        new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
        new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
        new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
        new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
        new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
    };

    static void Main()
    {
        // Task 1: Імена героїв, народжених у 1941
        Task1_Imperative();
        Task1_Declarative();

        // Task 2: Назви коміксів в алфавітному порядку
        Task2_Imperative();
        Task2_Declarative();

        // Task 3: Імена та роки народження, сортування за спаданням року
        Task3_Imperative();
        Task3_Declarative();
    }

    // === Task 1 ===
    static void Task1_Imperative()
    {
        Console.WriteLine("=== Task 1: Імперативний підхід ===");
        foreach (var hero in _heroes)
        {
            if (hero.YearOfBirth == 1941)
                Console.WriteLine(hero.Name);
        }
        Console.WriteLine();
    }

    static void Task1_Declarative()
    {
        Console.WriteLine("=== Task 1: Декларативний підхід ===");
        var heroes1941 = _heroes
            .Where(h => h.YearOfBirth == 1941)
            .Select(h => h.Name);

        foreach (var name in heroes1941)
            Console.WriteLine(name);
        Console.WriteLine();
    }

    // === Task 2 ===
    static void Task2_Imperative()
    {
        Console.WriteLine("=== Task 2: Імперативний підхід ===");
        var comicsList = new List<string>();
        foreach (var hero in _heroes)
            comicsList.Add(hero.Comics);

        comicsList.Sort();

        foreach (var comic in comicsList)
            Console.WriteLine(comic);
        Console.WriteLine();
    }

    static void Task2_Declarative()
    {
        Console.WriteLine("=== Task 2: Декларативний підхід ===");
        var comicsSorted = _heroes
            .Select(h => h.Comics)
            .OrderBy(c => c);

        foreach (var comic in comicsSorted)
            Console.WriteLine(comic);
        Console.WriteLine();
    }

    // === Task 3 ===
    static void Task3_Imperative()
    {
        Console.WriteLine("=== Task 3: Імперативний підхід ===");
        var list = new List<(string Name, int Year)>();
        foreach (var hero in _heroes)
            list.Add((hero.Name, hero.YearOfBirth));

        list.Sort((a, b) => b.Year.CompareTo(a.Year));

        foreach (var item in list)
            Console.WriteLine($"{item.Name} - {item.Year}");
        Console.WriteLine();
    }

    static void Task3_Declarative()
    {
        Console.WriteLine("=== Task 3: Декларативний підхід ===");
        var sortedHeroes = _heroes
            .OrderByDescending(h => h.YearOfBirth)
            .Select(h => new { h.Name, h.YearOfBirth });

        foreach (var hero in sortedHeroes)
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        Console.WriteLine();
    }
}
