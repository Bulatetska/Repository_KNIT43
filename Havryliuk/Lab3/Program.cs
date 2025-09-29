using System;
using System.Collections.Generic;
using System.Linq;

namespace LingLabWork
{
    class Program
    {
        // Клас супергероя
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
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА LINQ ===");
            Console.WriteLine("Початковий список героїв:");
            foreach (var hero in _heroes)
            {
                Console.WriteLine($"{hero.Name} ({hero.YearOfBirth}) - {hero.Comics}");
            }

            // Завдання 1: Герої 1941 року
            Console.WriteLine("\n--- Завдання 1: Герої 1941 року ---");
            
            // Імперативний підхід
            Console.WriteLine("\nІмперативний підхід:");
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

            // Декларативний підхід
            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var heroes1941Linq = from hero in _heroes
                                where hero.YearOfBirth == 1941
                                select hero.Name;
            foreach (var heroName in heroes1941Linq)
            {
                Console.WriteLine(heroName);
            }

            // Завдання 2: Комікси в алфавітному порядку
            Console.WriteLine("\n--- Завдання 2: Комікси в алфавітному порядку ---");
            
            // Імперативний підхід
            Console.WriteLine("\nІмперативний підхід:");
            var comics = new List<string>();
            foreach (var hero in _heroes)
            {
                if (!comics.Contains(hero.Comics))
                {
                    comics.Add(hero.Comics);
                }
            }
            comics.Sort();
            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }

            // Декларативний підхід
            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var comicsLinq = (from hero in _heroes
                             orderby hero.Comics
                             select hero.Comics).Distinct();
            foreach (var comic in comicsLinq)
            {
                Console.WriteLine(comic);
            }

            // Завдання 3: Імена та дати в порядку спадання
            Console.WriteLine("\n--- Завдання 3: Імена та дати народження в порядку спадання ---");
            
            // Імперативний підхід (описує як виконати задачу, тобто послідовність дій)
            Console.WriteLine("\nІмперативний підхід:");
            var heroInfo = new List<(string Name, int Year)>();
            foreach (var hero in _heroes)
            {
                heroInfo.Add((hero.Name, hero.YearOfBirth));
            }
            heroInfo.Sort((x, y) => y.Year.CompareTo(x.Year));
            foreach (var info in heroInfo)
            {
                Console.WriteLine($"{info.Name} - {info.Year}");
            }

            // Декларативний підхід (описує що потрібно зробити, а не як)
            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var heroInfoLinq = from hero in _heroes
                              orderby hero.YearOfBirth descending
                              select new { hero.Name, hero.YearOfBirth };
            foreach (var info in heroInfoLinq)
            {
                Console.WriteLine($"{info.Name} - {info.YearOfBirth}");
            }

        }
    }
}