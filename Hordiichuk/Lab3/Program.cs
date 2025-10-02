using System;
using System.Collections.Generic;
using System.Linq;

class Hero
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
    public string Comics { get; set; }
}

class Program
{
    static void Main()
    {
        var heroes = new List<Hero>
        {
            new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
            new Hero { Name = "Batman", YearOfBirth = 1939, Comics = "Detective Comics" },
            new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
            new Hero { Name = "Wonder Woman", YearOfBirth = 1941, Comics = "All Star Comics" },
            new Hero { Name = "Iron Man", YearOfBirth = 1963, Comics = "Tales of Suspense" },
            new Hero { Name = "Spider-Man", YearOfBirth = 1962, Comics = "Amazing Fantasy" }
        };


        Console.WriteLine("Task 1: Heroes born in 1941");


        foreach (var h in heroes)
        {
            if (h.YearOfBirth == 1941)
                Console.WriteLine(h.Name);
        }

        Console.WriteLine("--- Declarative (LINQ) ---");
        var born1941 = heroes.Where(h => h.YearOfBirth == 1941)
                             .Select(h => h.Name);
        foreach (var name in born1941)
            Console.WriteLine(name);



        Console.WriteLine("\nTask 2: Comics sorted alphabetically");


        var comicsList = new List<string>();
        foreach (var h in heroes)
        {
            if (!comicsList.Contains(h.Comics))
                comicsList.Add(h.Comics);
        }
        comicsList.Sort();
        foreach (var c in comicsList)
            Console.WriteLine(c);

        Console.WriteLine("--- Declarative (LINQ) ---");
        var comics = heroes.Select(h => h.Comics)
                           .Distinct()
                           .OrderBy(c => c);
        foreach (var c in comics)
            Console.WriteLine(c);



        Console.WriteLine("\nTask 3: Heroes sorted by birth year (descending)");


        var heroesSorted = new List<Hero>(heroes);
        heroesSorted.Sort((a, b) => b.YearOfBirth.CompareTo(a.YearOfBirth));
        foreach (var h in heroesSorted)
            Console.WriteLine($"{h.Name} - {h.YearOfBirth}");

        Console.WriteLine("--- Declarative (LINQ) ---");
        var sortedHeroes = heroes.OrderByDescending(h => h.YearOfBirth)
                                 .Select(h => new { h.Name, h.YearOfBirth });
        foreach (var h in sortedHeroes)
            Console.WriteLine($"{h.Name} - {h.YearOfBirth}");
    }
}
