using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesApp
{
    class Program
    {
        private class Hero { 
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
            public string Comics { get; set; }
        }

        private static readonly List<Hero> _heroes = new List<Hero>
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
                Name = "Captin America",
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
            //Lekcja

            //var heroNames = new List<String>();
            //foreach (var hero in _heroes)
            //{
            //    if (hero.Name.Contains("man"))
            //    {
            //        heroNames.Add(hero.Name);
            //    }
            //}
            //heroNames.Sort();
            //foreach(var heroName in heroNames)
            //{
            //    Console.WriteLine(heroName);
            //}

            //var heroNames = 
            //    from hero in _heroes
            //    where hero.Name.Contains("man")
            //    orderby hero.Name
            //    select hero;
            //foreach(var hero in heroNames)
            //{
            //    Console.WriteLine(hero.Name);
            //}

            //Zadanie 1 
            //імперативний підхід
            Console.WriteLine("Zadanie 1 \n Names of superheros, who born in 1941(Імперативний підхід): ");
            var names1 = new List<String>();
            foreach (var hero in _heroes)
            {
                if (hero.YearOfBirth == 1941)
                {
                    names1.Add(hero.Name);
                }
            }
            names1.Sort();
            foreach (var heroName in names1)
            {
                Console.WriteLine(heroName);
            }

            ////декларативний підхід
            Console.WriteLine("\n Names of superheros, who born in 1941(Деклеративний підхід): ");
            var names11 =
                from hero in _heroes
                where hero.YearOfBirth == 1941
                orderby hero.Name
                select hero;
            foreach (var hero in names11)
            {
                Console.WriteLine(hero.Name);
            }

            //Zadanie 2
            //імперативний підхід
            Console.WriteLine("\n Zadanie 2 \n Names of comics(Імперативний підхід): ");
            var names2 = new List<String>();
            foreach (var c in _heroes)
            {
                names2.Add(c.Comics);
            }
            names2.Sort();
            foreach (var c in names2)
            {
                Console.WriteLine(c);
            }

            //////декларативний підхід
            Console.WriteLine("\n Names of comics(Деклеративний підхід): ");
            var names22 =
                from hero in _heroes
                orderby hero.Comics
                select hero.Comics;
            foreach (var c in names22)
            {
                Console.WriteLine(c);
            }

            //Zadanie 3 
            //імперативний підхід
            Console.WriteLine("\n Zadanie 3 \n Names of comics(Імперативний підхід): ");
            List<(string Name, int Year)> names31 = new List<(string, int)>();
            foreach (var c in _heroes)
            {
                names31.Add((c.Name,c.YearOfBirth));
            }
            names31 = names31.OrderByDescending(x => x.Year).ToList();
            foreach (var c in names31)
            {
                Console.WriteLine("Name: " + c.Name + ", Year: " + c.Year);
            }

            //////декларативний підхід
            Console.WriteLine("\n Names of comics(Деклеративний підхід): ");
            var names32 =
                from hero in _heroes
                orderby hero.YearOfBirth descending
                select new { hero.Name, hero.YearOfBirth };
            foreach (var c in names32)
            {
                Console.WriteLine("Name: " + c.Name + ", Year: " + c.YearOfBirth);
            }
        }
    }
}
