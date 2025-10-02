namespace Lab3
{
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
                Console.WriteLine();
            }

            {
                var heroNames =
                    from hero in _heroes
                    where hero.Name.Contains("man")
                    orderby hero.Name
                    select hero.Name;
                foreach (var hero in heroNames)
                {
                    Console.WriteLine(hero);
                }
                Console.WriteLine();
            }

            {
                var heroNames = _heroes
                    .Where(hero => hero.Name.Contains("man"))
                    .OrderBy(hero => hero.Name)
                    .Select(hero => hero.Name);
                foreach (var hero in heroNames)
                {
                    Console.WriteLine(hero);
                }
                Console.WriteLine();
            }

            {
                var shouldBeSorted = false;

                var query = _heroes.Where((hero, index) =>
                    hero.Name.Contains("man"));
                if (shouldBeSorted)
                    query = query.OrderBy(hero => hero.Name);
                var heroNames = query
                 .Select(hero => hero.Name);
                foreach (var hero in heroNames)
                {
                    Console.WriteLine(hero);
                }
            }

            {
                Console.WriteLine("\n1. Вивести імена супергероїв, які народилися 1941 р.");

                {
                    Console.WriteLine("a)");
                    foreach (var hero in _heroes)
                    {
                        if (hero.YearOfBirth == 1941)
                        {
                            Console.WriteLine(hero.Name);
                        }
                    }
                }

                {
                    Console.WriteLine("b)");
                    var heroNames =
                        from hero in _heroes
                        where hero.YearOfBirth == 1941
                        select hero.Name;
                    foreach (var hero in heroNames)
                    {
                        Console.WriteLine(hero);
                    }
                }
            }

            {
                Console.WriteLine("\n2. Вивести назви коміксів і відсортувати їх в алфавітному порядку");

                {
                    Console.WriteLine("a)");
                    var comicsNames = new List<string>();
                    foreach (var hero in _heroes)
                    {
                        comicsNames.Add(hero.Comics);
                    }
                    comicsNames.Sort();
                    foreach (var comics in comicsNames)
                    {
                        Console.WriteLine(comics);
                    }
                }

                {
                    Console.WriteLine("b)");
                    var comicsNames =
                        from hero in _heroes
                        orderby hero.Comics
                        select hero.Comics;
                    foreach (var comics in comicsNames)
                    {
                        Console.WriteLine(comics);
                    }
                }
            }

            {
                Console.WriteLine("\n3. Вивести імена супергероїв та дати їх народження і відсортувати їх в порядку спадання дат їх народження.");

                {
                    Console.WriteLine("a)");
                    var heroes = new List<Hero>(_heroes);
                    heroes.Sort((h1, h2) => h2.YearOfBirth.CompareTo(h1.YearOfBirth));
                    foreach (var hero in heroes)
                    {
                        Console.WriteLine("{0} {1}", hero.Name, hero.YearOfBirth);
                    }
                }

                {
                    Console.WriteLine("b)");
                    var heroes =
                        from hero in _heroes
                        orderby hero.YearOfBirth descending
                        select hero;
                    foreach (var hero in heroes)
                    {
                        Console.WriteLine("{0} {1}", hero.Name, hero.YearOfBirth);
                    }
                }
            }
        }
    }
}
