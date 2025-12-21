using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTestApp
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Task1();
            Task1_Linq();

            Task2();
            Task2_Linq();

            Task3();
            Task3_Linq();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        static void Task1()
        {
            Console.WriteLine("\n Завдання 1: Імперативний підхід");
            Console.WriteLine("Вивести імена супергероїв, які народилися 1941 р.");

            var heroes1941 = new List<string>();

            foreach (var hero in _heroes)
            {
                if (hero.YearOfBirth == 1941)
                {
                    heroes1941.Add(hero.Name);
                }
            }

            foreach (var name in heroes1941)
            {
                Console.WriteLine(name);
            }
        }

        static void Task1_Linq()
        {
            Console.WriteLine("\n Завдання 1: Декларативний (LINQ)");

            var heroes1941 = from hero in _heroes
                             where hero.YearOfBirth == 1941
                             select hero.Name;

            foreach (var name in heroes1941)
            {
                Console.WriteLine(name);
            }
        }

        static void Task2()
        {
            Console.WriteLine("\n Завдання 2: Імперативний підхід");
            Console.WriteLine("Вивести назви коміксів і відсортувати їх в алфавітному порядку.");

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

        static void Task2_Linq()
        {
            Console.WriteLine("\n Завдання 2: Декларативний (LINQ)");

            var comics = from hero in _heroes
                         orderby hero.Comics
                         select hero.Comics;

            foreach (var c in comics)
            {
                Console.WriteLine(c);
            }
        }

        static void Task3()
        {
            Console.WriteLine("\n Завдання 3: Імперативний підхід");
            Console.WriteLine("Вивести імена супергероїв та дати їх народження у порядку спадання дат.");

            var sortedHeroes = new List<Hero>(_heroes);
            sortedHeroes.Sort((h1, h2) => h2.YearOfBirth.CompareTo(h1.YearOfBirth));

            foreach (var hero in sortedHeroes)
            {
                Console.WriteLine($"{hero.Name} — {hero.YearOfBirth}");
            }
        }

        static void Task3_Linq()
        {
            Console.WriteLine("\n Завдання 3: Декларативний (LINQ)");

            var sortedHeroes = from hero in _heroes
                               orderby hero.YearOfBirth descending
                               select new { hero.Name, hero.YearOfBirth };

            foreach (var hero in sortedHeroes)
            {
                Console.WriteLine($"{hero.Name} — {hero.YearOfBirth}");
            }
        }
    }
}
