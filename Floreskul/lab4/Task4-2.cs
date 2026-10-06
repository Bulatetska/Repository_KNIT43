using System;
using System.Collections.Generic;
using System.Linq;

class Task4_2
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
            "Завдання 2: Назви коміксів в алфавітному порядку"
        );

        Console.WriteLine();
        Console.WriteLine("1. Імперативний підхід");

        var comicsImperative = new List<string>();

        foreach (var hero in heroes)
        {
            if (hero.Comics != null)
            {
                comicsImperative.Add(hero.Comics);
            }
        }

        comicsImperative.Sort();

        foreach (var comic in comicsImperative)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine();
        Console.WriteLine("2. Декларативний підхід (LINQ)");

        var comicsLinq = heroes
            .Select(hero => hero.Comics)
            .OrderBy(comicTitle => comicTitle);

        foreach (var comic in comicsLinq)
        {
            Console.WriteLine(comic);
        }
    }
}