using System;
using System.Collections.Generic;
using System.Linq;

class Hero
{
    public string Name { get; set; } = "";
    public int YearOfBirth { get; set; }
    public string Comics { get; set; } = "";
}

class Program
{
    static List<Hero> heroes = new List<Hero>
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

    static void Main()
    {
        // 1

        Console.WriteLine("1. Імперативний:");

        foreach (var hero in heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                Console.WriteLine(hero.Name);
            }
        }

        Console.WriteLine();


        // 1

        Console.WriteLine("1. Декларативний:");

        var heroNames =
            from hero in heroes
            where hero.YearOfBirth == 1941
            select hero.Name;

        foreach (var name in heroNames)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();


        // 2

        Console.WriteLine("2. Імперативний:");
        var comics = new List<string>();

        foreach (var hero in heroes)
        {
            comics.Add(hero.Comics);
        }

        comics.Sort();

        foreach (var comic in comics)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine();


        // 2

        Console.WriteLine("2. Декларативний:");
        var comicsLinq =
            from hero in heroes
            orderby hero.Comics
            select hero.Comics;

        foreach (var comic in comicsLinq)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine();


        // 3

        Console.WriteLine("2. Імперативний:");
        for (int i = 0; i < heroes.Count; i++)
        {
            for (int j = i + 1; j < heroes.Count; j++)
            {
                if (heroes[i].YearOfBirth < heroes[j].YearOfBirth)
                {
                    Hero temp = heroes[i];
                    heroes[i] = heroes[j];
                    heroes[j] = temp;
                }
            }
        }

        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
        }


        // 3

        Console.WriteLine("3. Декларативний:");

        var sortedHeroesLinq =
            from hero in heroes
            orderby hero.YearOfBirth descending
            select hero;

        foreach (var hero in sortedHeroesLinq)
        {
            Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
        }
    }
}