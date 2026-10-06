using System;
using System.Collections.Generic;
using System.Linq;

class Task4_3
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
        Console.WriteLine(
            "Завдання 3: Імена та дати народження за спаданням"
        );

        Console.WriteLine();
        Console.WriteLine("1. Імперативний підхід");

        var sortedHeroesImperative = new List<Hero>(heroes);

        sortedHeroesImperative.Sort(
            (a, b) => b.YearOfBirth.CompareTo(a.YearOfBirth)
        );

        foreach (var hero in sortedHeroesImperative)
        {
            Console.WriteLine(
                $"{hero.Name} — {hero.YearOfBirth}"
            );
        }

        Console.WriteLine();
        Console.WriteLine("2. Декларативний підхід (LINQ)");

        var sortedHeroesLinq = heroes
            .OrderByDescending(hero => hero.YearOfBirth)
            .Select(
                hero => $"{hero.Name} — {hero.YearOfBirth}"
            );

        foreach (var line in sortedHeroesLinq)
        {
            Console.WriteLine(line);
        }
    }
}