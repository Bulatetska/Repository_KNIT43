using System;
using System.Linq;
using System.Collections.Generic;

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

    static void Main(string[] args)
    {
        Console.WriteLine("=== Імперативний підхід ===");
        ImperativeTasks();

        Console.WriteLine("\n=== Декларативний (LINQ) підхід ===");
        DeclarativeTasks();
    }

    static void ImperativeTasks()
    {
        Console.WriteLine("1. Герої 1941 р.:");
        foreach (var hero in _heroes)
        {
            if (hero.YearOfBirth == 1941)
                Console.WriteLine(hero.Name);
        }

        Console.WriteLine("\n2. Комікси (сортування):");
        var comicsList = new List<string>();
        foreach (var hero in _heroes)
        {
            comicsList.Add(hero.Comics);
        }
        comicsList.Sort();
        foreach (var comics in comicsList)
        {
            Console.WriteLine(comics);
        }

        Console.WriteLine("\n3. Герої за роком народження (спадання):");
        var heroesSorted = new List<Hero>(_heroes);
        heroesSorted.Sort((h1, h2) => h2.YearOfBirth.CompareTo(h1.YearOfBirth));
        foreach (var hero in heroesSorted)
        {
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }
    }

    static void DeclarativeTasks()
    {
        Console.WriteLine("1. Герої 1941 р.:");
        var heroes1941 = from hero in _heroes
                         where hero.YearOfBirth == 1941
                         select hero.Name;
        foreach (var name in heroes1941)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n2. Комікси (сортування):");
        var comicsSorted = from hero in _heroes
                           orderby hero.Comics
                           select hero.Comics;
        foreach (var comics in comicsSorted)
        {
            Console.WriteLine(comics);
        }

        Console.WriteLine("\n3. Герої за роком народження (спадання):");
        var heroesByYear = from hero in _heroes
                           orderby hero.YearOfBirth descending
                           select new { hero.Name, hero.YearOfBirth };
        foreach (var hero in heroesByYear)
        {
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }
    }
}
