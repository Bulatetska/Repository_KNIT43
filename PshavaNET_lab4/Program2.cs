using System;
using System.Collections.Generic;
using System.Linq;

//ДЕКЛАРАТИВНИЙ ПІДХІД(LINQ)
namespace PshavaNET_lab4
{
    internal class Program2
    {
        static readonly List<Hero> _heroes = new List<Hero>
        {
            new Hero { Name = "Superman", YearOfBirth = 1938, Comics = "Action Comics" },
            new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
            new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
            new Hero { Name = "Ironman", YearOfBirth = 1963, Comics = "Tales of Suspense" },
            new Hero { Name = "Spiderman", YearOfBirth = 1963, Comics = "Amazing Fantasy" }
        };

        static void Main(string[] args)
        {
            //1. Вивести імена супергероїв, які народилися 1941 р.
            Console.WriteLine("ДЕКЛАРАТИВНИЙ ПІДХІД");
            Console.WriteLine("Супергерої які народились у 1941: ");
            var heroes1941 = _heroes
                .Where(h => h.YearOfBirth == 1941)
                .Select(h => h.Name);

            foreach (var name in heroes1941)
            {
                Console.WriteLine(name);
            }

            //2. Вивести назви коміксів і відсортувати їх в алфавітному порядку
            Console.WriteLine("\nВідсортовані назви коміксів: ");
            var comics = _heroes
                .Select(h => h.Comics)
                .OrderBy(title => title);

            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }

            //3. Вивести імена супергероїв та дати їх народження і відсортувати їх в порядку спадання дат їх народження.
            Console.WriteLine("\nВідсортовані імена супергероїв за датою: ");
            var sortedHeroes = _heroes
                .OrderByDescending(h => h.YearOfBirth);

            foreach (var hero in sortedHeroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine(hero.YearOfBirth);
            }
        }
    }
    internal class Hero
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Comics { get; set; }
    }
}