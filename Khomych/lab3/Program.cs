using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTasksApp
{
    public class Hero
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Comics { get; set; }
    }

    class Program
    {
        private static readonly List<Hero> heroes = new List<Hero>
        {
            new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
            new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
            new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
            new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
            new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== Завдання 1: Імена супергероїв, які народилися 1941 р. ===");
            
            Console.WriteLine("Імперативний підхід:");
            List<string> heroes1941 = new List<string>();
            foreach (var hero in heroes)
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

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var heroes1941Linq = heroes
                .Where(hero => hero.YearOfBirth == 1941)
                .Select(hero => hero.Name);
            foreach (var name in heroes1941Linq)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("=== Завдання 2: Назви коміксів в алфавітному порядку ===");
            
            Console.WriteLine("Імперативний підхід:");
            List<string> comicsList = new List<string>();
            foreach (var hero in heroes)
            {
                comicsList.Add(hero.Comics);
            }
            comicsList.Sort(); 
            foreach (var comic in comicsList)
            {
                Console.WriteLine(comic);
            }

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var comicsLinq = heroes
                .Select(hero => hero.Comics)
                .OrderBy(comic => comic);
            foreach (var comic in comicsLinq)
            {
                Console.WriteLine(comic);
            }

            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("=== Завдання 3: Імена та дати народження за спаданням дат ===");
            
            Console.WriteLine("Імперативний підхід:");
            List<Hero> sortedHeroes = new List<Hero>(heroes);
            sortedHeroes.Sort((h1, h2) => h2.YearOfBirth.CompareTo(h1.YearOfBirth));
            foreach (var hero in sortedHeroes)
            {
                Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
            }

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var sortedHeroesLinq = heroes
                .OrderByDescending(hero => hero.YearOfBirth)
                .Select(hero => new { hero.Name, hero.YearOfBirth }); 
            foreach (var hero in sortedHeroesLinq)
            {
                Console.WriteLine($"{hero.Name} - {hero.YearOfBirth}");
            }
            
            Console.ReadLine();
        }
    }
}