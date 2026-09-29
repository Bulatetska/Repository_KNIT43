using System.Linq;

namespace Lab_4
{

    class Hero
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Comics { get; set; }
    }

    class Program
    {
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
            var heroNames =
                from hero in _heroes
                where hero.Name.Contains("man")
                orderby hero.Name
                select hero.Name;
            foreach (string hero in heroNames)
            {
                Console.WriteLine(hero);
            }

            task_3();
            

        }

        static void task_1()
        {
            var heroes = _heroes
                .Where(h => h.YearOfBirth == 1941)
                .Select(h => h.Name);

            Console.WriteLine("Born in 1941:");
            foreach (string name in heroes)
            {
                Console.WriteLine(name);
            }
        }


        static void task_2()
        {
            var comics = _heroes
                .Select(h => h.Comics)
                .Distinct()
                .OrderBy(c => c);

            Console.WriteLine("Comics by alphabet:");
            foreach (string comic in comics) 
            { 
                Console.WriteLine(comic);
            }
        }


        static void task_3()
        {
            var heroes = _heroes
                .OrderByDescending(h => h.YearOfBirth)
                .Select(h => new { h.Name, h.YearOfBirth });

            Console.WriteLine("Heros by descending year:");
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Name + "-" + hero.YearOfBirth);
            }
        }

    }
}