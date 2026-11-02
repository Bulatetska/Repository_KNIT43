
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
    static void Main()
    {
        List<Hero> heroes = new List<Hero>
        {
            new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
            new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
            new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
            new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
            new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
        };

        // ЗАВДАННЯ З ЛЕКЦІЇ
        Console.WriteLine("Завдання з лекції");

        Console.WriteLine("Імперативний підхід:");

        List<string> names = new List<string>();

        foreach (var hero in heroes)
        {
            if (hero.Name.Contains("man"))
            {
                names.Add(hero.Name);
            }
        }

        names.Sort();

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("Декларативний підхід:");

        var result = heroes
            .Where(hero => hero.Name.Contains("man"))
            .OrderBy(hero => hero.Name)
            .Select(hero => hero.Name);

        foreach (var name in result)
        {
            Console.WriteLine(name);
        }


        // ЗАВДАННЯ 1
        Console.WriteLine("\nЗавдання 1. Герої 1941 року");

        Console.WriteLine("Імперативний підхід:");

        foreach (var hero in heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                Console.WriteLine(hero.Name);
            }
        }

        Console.WriteLine("Декларативний підхід:");

        var result1 = heroes
            .Where(hero => hero.YearOfBirth == 1941)
            .Select(hero => hero.Name);

        foreach (var name in result1)
        {
            Console.WriteLine(name);
        }


        // ЗАВДАННЯ 2
        Console.WriteLine("\nЗавдання 2. Назви коміксів");

        Console.WriteLine("Імперативний підхід:");

        List<string> comics = new List<string>();

        foreach (var hero in heroes)
        {
            comics.Add(hero.Comics);
        }

        comics.Sort();

        foreach (var comic in comics)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine("Декларативний підхід:");

        var result2 = heroes
            .OrderBy(hero => hero.Comics)
            .Select(hero => hero.Comics);

        foreach (var comic in result2)
        {
            Console.WriteLine(comic);
        }


        // ЗАВДАННЯ 3
        Console.WriteLine("\nЗавдання 3. Герої за роком народження");

        Console.WriteLine("Імперативний підхід:");

        List<Hero> sortedHeroes = new List<Hero>(heroes);

        sortedHeroes.Sort((a, b) =>
            b.YearOfBirth.CompareTo(a.YearOfBirth));

        foreach (var hero in sortedHeroes)
        {
            Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
        }

        Console.WriteLine("Декларативний підхід:");

        var result3 = heroes
            .OrderByDescending(hero => hero.YearOfBirth);

        foreach (var hero in result3)
        {
            Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
        }
    }
}
