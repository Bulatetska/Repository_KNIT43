﻿﻿using System;
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

    private static readonly List<Hero> heroes = new List<Hero>
    {
        new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
        new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
        new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
        new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
        new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
    };

    static void Main()
    {
        Console.WriteLine("===== ЗАВДАННЯ 1 =====");
        Task1();
        Console.WriteLine("\n===== ЗАВДАННЯ 2 =====");
        Task2();
        Console.WriteLine("\n===== ЗАВДАННЯ 3 =====");
        Task3();
    }

    static void Task1()
    {
        Console.WriteLine("Імперативний підхід:");
        List<string> result1 = new List<string>();
        foreach (var hero in heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                result1.Add(hero.Name);
            }
        }
        foreach (var name in result1)
            Console.WriteLine(name);

        Console.WriteLine("\nДекларативний підхід (LINQ):");
        var result2 = from hero in heroes
                      where hero.YearOfBirth == 1941
                      select hero.Name;
        foreach (var name in result2)
            Console.WriteLine(name);
    }

    static void Task2()
    {
        Console.WriteLine("Імперативний підхід:");
        List<string> comicsList = new List<string>();
        foreach (var hero in heroes)
        {
            comicsList.Add(hero.Comics);
        }
        comicsList.Sort();
        foreach (var c in comicsList)
            Console.WriteLine(c);

        Console.WriteLine("\nДекларативний підхід (LINQ):");
        var sortedComics = from hero in heroes
                           orderby hero.Comics
                           select hero.Comics;
        foreach (var c in sortedComics)
            Console.WriteLine(c);
    }

    static void Task3()
    {
        Console.WriteLine("Імперативний підхід:");
        List<Hero> sortedHeroes = new List<Hero>(heroes);
        sortedHeroes.Sort((a, b) => b.YearOfBirth.CompareTo(a.YearOfBirth));
        foreach (var hero in sortedHeroes)
            Console.WriteLine($"{hero.Name} — {hero.YearOfBirth}");

        Console.WriteLine("\nДекларативний підхід (LINQ):");
        var result = from hero in heroes
                     orderby hero.YearOfBirth descending
                     select new { hero.Name, hero.YearOfBirth };
        foreach (var h in result)
            Console.WriteLine($"{h.Name} — {h.YearOfBirth}");
    }
}