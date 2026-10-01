using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ІМПЕРАТИВНИЙ ПІДХІД
namespace PshavaNET_lab4
{

    internal class Program
    {
        private class Hero
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
            public string Comics { get; internal set; }
        }
        public string Comics { get; set; }
        static readonly List<Hero> _heroes = new List<Hero>
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
            //1. Вивести імена супергероїв, які народилися 1941 р.
            var heroNames = new List<string>();
            foreach (var hero in _heroes)
            {
                if (hero.YearOfBirth == 1941)
                {
                    heroNames.Add(hero.Name);
                }
            }
            foreach (var heroName in heroNames)
            {
                Console.WriteLine("Супер герої які народились у 1941: ");
                Console.WriteLine(heroName);
            }

            //2. Вивести назви коміксів і відсортувати їх в алфавітному порядку
            List<string> comics = new List<string>();
            Console.WriteLine("\nВідсортовані назви коміксів: ");

            foreach (var hero in _heroes)
            {
                comics.Add(hero.Comics);
            }
            comics.Sort();

            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }

            //3. Вивести імена супергероїв та дати їх народження і відсортувати їх в порядку спадання дат їх народження.
            List<Hero> information = new List<Hero>(_heroes);

            information.Sort((a, b) => b.YearOfBirth.CompareTo(a.YearOfBirth));
            Console.WriteLine("\nВідсортовані імена супергероїв за датою: ");

            foreach(var hero in information)
            {
                Console.WriteLine(hero.Name); Console.WriteLine(hero.YearOfBirth);
            }
        }
    }
}