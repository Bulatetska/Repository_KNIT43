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
        // Завдання 1. Імперативний підхід
        Console.WriteLine("Завдання 1. Імперативний підхід:");

        var heroes1941 = new List<string>();

        foreach (var hero in _heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                heroes1941.Add(hero.Name);
            }
        }

        foreach (var heroName in heroes1941)
        {
            Console.WriteLine(heroName);
        }


        // Завдання 1. Декларативний підхід
        Console.WriteLine("\nЗавдання 1. Декларативний підхід:");

        var heroes1941Linq = _heroes
            .Where(hero => hero.YearOfBirth == 1941)
            .Select(hero => hero.Name);

        foreach (var heroName in heroes1941Linq)
        {
            Console.WriteLine(heroName);
        }


        // Завдання 2. Імперативний підхід
        Console.WriteLine("\nЗавдання 2. Імперативний підхід:");

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


        // Завдання 2. Декларативний підхід
        Console.WriteLine("\nЗавдання 2. Декларативний підхід:");

        var comicsLinq = _heroes
            .Select(hero => hero.Comics)
            .OrderBy(comic => comic);

        foreach (var comic in comicsLinq)
        {
            Console.WriteLine(comic);
        }


        // Завдання 3. Імперативний підхід
        Console.WriteLine("\nЗавдання 3. Імперативний підхід:");

        var heroesSorted = new List<Hero>();

        foreach (var hero in _heroes)
        {
            heroesSorted.Add(hero);
        }

        heroesSorted.Sort((hero1, hero2) =>
            hero2.YearOfBirth.CompareTo(hero1.YearOfBirth));

        foreach (var hero in heroesSorted)
        {
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }


        // Завдання 3. Декларативний підхід
        Console.WriteLine("\nЗавдання 3. Декларативний підхід:");

        var heroesSortedLinq = _heroes
            .OrderByDescending(hero => hero.YearOfBirth)
            .Select(hero => new
            {
                hero.Name,
                hero.YearOfBirth
            });

        foreach (var hero in heroesSortedLinq)
        {
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }
    }
}