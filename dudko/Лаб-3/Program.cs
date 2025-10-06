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
        new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
        new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
        new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
        new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
        new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
    };

    static void Main(string[] args)
    {
        Console.WriteLine("===(імперативний) Завдання 1 Вивести імена супергероїв, які народилися 1941 р.===");
        foreach (var hero in _heroes)
        {
            if (hero.YearOfBirth == 1941)
            {
                Console.WriteLine(hero.Name);
            }
        }

        Console.WriteLine("=== Декларативний стиль ===");
        var born1941 =
        from hero in _heroes
        where hero.YearOfBirth == 1941
        select hero.Name;

        foreach (var name in born1941)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("-----------------------------\n");

        Console.WriteLine("=== Завдання 2 Вивести назви коміксів і відсортувати їх в алфавітному порядку (імперативний) ===");
        List<string> comicsList = new List<string>();

        foreach (var hero in _heroes)
        {
            comicsList.Add(hero.Comics);
        }

        comicsList.Sort();

        foreach (var comics in comicsList)
        {
            Console.WriteLine(comics);
        }

        Console.WriteLine("=== Декларативний стиль ===");

        var comicsSorted =
        from hero in _heroes
        orderby hero.Comics
        select hero.Comics;

        foreach (var comics in comicsSorted)
        {
            Console.WriteLine(comics);
        }

        Console.WriteLine("-----------------------------\n");

        Console.WriteLine("Завдання 3 Вивести імена супергероїв та дати їх народження і відсортувати їх в порядку спадання дат їх народження. (імперативний) ===");

        List<Hero> sortedHeroes = new List<Hero>(_heroes);
        sortedHeroes.Sort(CompareHeroesByBirthYearDesc);

        foreach (var hero in sortedHeroes)
        {
            Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }

        static int CompareHeroesByBirthYearDesc(Hero a, Hero b)
        {
            return b.YearOfBirth.CompareTo(a.YearOfBirth);
        }

        Console.WriteLine("\n=== Декларативний стиль ===");

        var sortedDesc =
        from hero in _heroes
        orderby hero.YearOfBirth descending
        select hero.Name + " - " + hero.YearOfBirth;

        foreach (var item in sortedDesc)
        {
            Console.WriteLine(item);
        }
       

    }
}

