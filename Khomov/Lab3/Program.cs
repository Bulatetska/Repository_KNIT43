class Program
{
    class Hero
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

            foreach (var heroName in heroNames)
            {
                Console.WriteLine(heroName);
            }

            Console.WriteLine();
        }

        {
            var heroNames = _heroes
                .Where(hero => hero.Name.Contains("man"))
                .OrderBy(hero => hero.Name)
                .Select(hero => hero.Name);

            foreach (var heroName in heroNames)
            {
                Console.WriteLine(heroName);
            }

            Console.WriteLine();
        }

        {
            var shouldBeSorted = true;

            var query = _heroes.Where((hero, index) =>
                hero.Name.Contains("man"));

            if (shouldBeSorted)
                query = query.OrderBy(hero => hero.Name);

            var heroNames = query.Select(hero => hero.Name);

            foreach (var hero in heroNames)
            {
                Console.WriteLine(hero);
            }

            Console.WriteLine();
        }

        {
            Console.WriteLine("1. Вивести імена супергероїв, які народилися 1941 р.");
            {
                Console.WriteLine("Імперативний підхід:");
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
                    Console.WriteLine(heroName);
                }

                Console.WriteLine();
            }

            {
                Console.WriteLine("Декларативний підхід:");
                var heroNames = _heroes
                    .Where(hero => hero.YearOfBirth == 1941)
                    .Select(hero => hero.Name);

                foreach (var heroName in heroNames)
                {
                    Console.WriteLine(heroName);
                }

                Console.WriteLine();
            }
        }

        {
            Console.WriteLine("2. Вивести назви коміксів і відсортувати їх в алфавітному порядку");
            {
                Console.WriteLine("Імперативний підхід:");
                var comics = new List<string>();

                foreach (var hero in _heroes)
                {
                    comics.Add(hero.Comics);
                }

                comics.Sort();

                foreach (var comic in comics)
                {
                    Console.WriteLine(comic);
                }

                Console.WriteLine();
            }

            {
                Console.WriteLine("Декларативний підхід:");
                var comics = _heroes
                    .OrderBy(hero => hero.Comics)
                    .Select(hero => hero.Comics);

                foreach (var comic in comics)
                {
                    Console.WriteLine(comic);
                }

                Console.WriteLine();
            }
        }

        {
            Console.WriteLine("3. Вивести імена супергероїв та дати їх народження і відсортувати їх в порядку спадання дат їх народження.");

            {
                Console.WriteLine("Імперативний підхід:");

                var heroesCopy = new List<Hero>(_heroes);

                heroesCopy.Sort((h1, h2) => h2.YearOfBirth.CompareTo(h1.YearOfBirth));

                foreach (var hero in heroesCopy)
                {
                    Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
                }

                Console.WriteLine();
            }

            {
                Console.WriteLine("Декларативний підхід:");

                var sortedHeroes = _heroes
                    .OrderByDescending(hero => hero.YearOfBirth)
                    .Select(hero => new { hero.Name, hero.YearOfBirth });

                foreach (var hero in sortedHeroes)
                {
                    Console.WriteLine(hero.Name + " - " + hero.YearOfBirth);
                }

                Console.WriteLine();
            }
        }
    }
}
