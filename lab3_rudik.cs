using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    internal class Program
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
            Console.WriteLine("=== Імперативний підхід ===");
            Task1_Imperative();
            Task2_Imperative();
            Task3_Imperative();

            Console.WriteLine("\n=== Декларативний підхід (LINQ) ===");
            Task1_Declarative();
            Task2_Declarative();
            Task3_Declarative();
        }

        static void Task1_Imperative()
        {
            Console.WriteLine("1. Імена героїв, які народилися 1941 р.:");
            foreach (var hero in _heroes)
            {
                if (hero.YearOfBirth == 1941)
                    Console.WriteLine(hero.Name);
            }
        }

        static void Task2_Imperative()
        {
            Console.WriteLine("\n2. Назви коміксів (відсортовані):");
            var comics = new List<string>();
            foreach (var hero in _heroes)
            {
                comics.Add(hero.Comics);
            }
            comics.Sort();
            foreach (var c in comics)
            {
                Console.WriteLine(c);
            }
        }

        static void Task3_Imperative()
        {
            Console.WriteLine("\n3. Імена героїв і дати народження (спадання):");
            var sorted = new List<Hero>(_heroes);
            sorted.Sort((a, b) => b.YearOfBirth.CompareTo(a.YearOfBirth));
            foreach (var hero in sorted)
            {
                Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
            }
        }

        static void Task1_Declarative()
        {
            Console.WriteLine("1. Імена героїв, які народилися 1941 р.:");
            var heroes1941 = _heroes.Where(h => h.YearOfBirth == 1941).Select(h => h.Name);
            foreach (var name in heroes1941)
                Console.WriteLine(name);
        }

        static void Task2_Declarative()
        {
            Console.WriteLine("\n2. Назви коміксів (відсортовані):");
            var comics = _heroes.Select(h => h.Comics).OrderBy(c => c);
            foreach (var c in comics)
                Console.WriteLine(c);
        }

        static void Task3_Declarative()
        {
            Console.WriteLine("\n3. Імена героїв і дати народження (спадання):");
            var sorted = _heroes.OrderByDescending(h => h.YearOfBirth).Select(h => new { h.Name, h.YearOfBirth });
            foreach (var hero in sorted)
                Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
        }
    }
}
