using System;
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
        var heroNames = new List<string>();

        foreach (var hero in _heroes)
        {
            if (hero.Name.Contains("man"))
            {
                heroNames.Add(hero.Name);
            }
        }

        heroNames.Sort();

        foreach (var heroName in heroNames)
        {
            Console.WriteLine(heroName);
        }
    }
}
