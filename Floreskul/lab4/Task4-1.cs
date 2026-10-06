using System;
using System.Collections.Generic;
using System.Linq;

class Hero
{
    public string? Name { get; set; }
    public int YearOfBirth { get; set; }
    public string? Comics { get; set; }
}

class Task4_1
{
    private static readonly List<Hero> heroes = new List<Hero>
    {
        new Hero
        {
            Name = "Superman",
            YearOfBirth = 1938,
            Comics = "Action Comics"
        },

        new Hero
        {
            Name = "Batman",
            YearOfBirth = 1938,
            Comics = "Detective Comics"
        },

        new Hero
        {
            Name = "Captain America",
            YearOfBirth = 1941,
            Comics = "Captain America Comics"
        },

        new Hero
        {
            Name = "Ironman",
            YearOfBirth = 1963,
            Comics = "Tales of Suspense"
        },

        new Hero
        {
            Name = "Spiderman",
            YearOfBirth = 1963,
            Comics = "Amazing Fantasy"
        }
    };

    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine();
        Console.WriteLine("Завдання 1: Супергерої 1941 року народження");

        Console.WriteLine();
        Console.WriteLine("1. Імперативний підхід");

        var names1941Imperative = new List<string>();

        foreach (var hero in heroes)
        {
            if (hero.YearOfBirth == 1941 && hero.Name != null)
            {
                names1941Imperative.Add(hero.Name);
            }
        }

        foreach (var name in names1941Imperative)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();
        Console.WriteLine("2. Декларативний підхід (LINQ)");

        var names1941Linq = heroes
            .Where(hero => hero.YearOfBirth == 1941)
            .Select(hero => hero.Name);

        foreach (var name in names1941Linq)
        {
            Console.WriteLine(name);
        }
    }
}
