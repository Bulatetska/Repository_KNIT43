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

    static void Main(string[] args)
    {
        // Task 1
        Console.WriteLine("===== TASK 1 =====");
        Console.WriteLine("Imperative approach:");

        foreach (var hero in _heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                Console.WriteLine(hero.Name);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Declarative approach (LINQ):");

        var heroes1941 = _heroes
            .Where(hero => hero.YearOfBirth == 1941)
            .Select(hero => hero.Name);

        foreach (var name in heroes1941)
        {
            Console.WriteLine(name);
        }


        // Task 2
        Console.WriteLine();
        Console.WriteLine("===== TASK 2 =====");
        Console.WriteLine("Imperative approach:");

        var comics = new List<string>();

        foreach (var hero in _heroes)
        {
            comics.Add(hero.Comics);
        }

        comics.Sort();

        foreach (var comic in comics)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine();
        Console.WriteLine("Declarative approach (LINQ):");

        var sortedComics = _heroes
            .Select(hero => hero.Comics)
            .OrderBy(comic => comic);

        foreach (var comic in sortedComics)
        {
            Console.WriteLine(comic);
        }


        // Task 3
        Console.WriteLine();
        Console.WriteLine("===== TASK 3 =====");
        Console.WriteLine("Imperative approach:");

        var sortedHeroes = new List<Hero>();

        foreach (var hero in _heroes)
        {
            sortedHeroes.Add(hero);
        }

        for (int i = 0; i < sortedHeroes.Count - 1; i++)
        {
            for (int j = 0; j < sortedHeroes.Count - 1 - i; j++)
            {
                if (sortedHeroes[j].YearOfBirth <
                    sortedHeroes[j + 1].YearOfBirth)
                {
                    Hero temp = sortedHeroes[j];
                    sortedHeroes[j] = sortedHeroes[j + 1];
                    sortedHeroes[j + 1] = temp;
                }
            }
        }

        foreach (var hero in sortedHeroes)
        {
            Console.WriteLine(
                hero.Name + " - " + hero.YearOfBirth
            );
        }

        Console.WriteLine();
        Console.WriteLine("Declarative approach (LINQ):");

        var heroesByYear = _heroes
            .OrderByDescending(hero => hero.YearOfBirth)
            .Select(hero => new
            {
                hero.Name,
                hero.YearOfBirth
            });

        foreach (var hero in heroesByYear)
        {
            Console.WriteLine(
                hero.Name + " - " + hero.YearOfBirth
            );
        }
    }
}