using System.Linq;
using System;
public class Hero
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
    public string Comics { get; set; }
}
public class Program
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
        Console.WriteLine("=== Imperative Approach ===");
        Imperial();
        Console.WriteLine("\n=== Declarative Approach ===");
        Declarative();
    }
    static void Imperial()
    {
        static void FindHeroesByYearOfBirth()
        {
            var heroesyerofbirth = new List<Hero>();
            foreach (var hero in _heroes)
            {
                if (hero.YearOfBirth == 1941)
                {
                    heroesyerofbirth.Add(hero);
                    Console.WriteLine($"Name: {hero.Name}");
                }
            }
        }
        FindHeroesByYearOfBirth();
        static void SortWithCustomBubbleSort()
        {

            Hero[] heroesArray = _heroes.ToArray();

            // Bubble Sort для рядків
            for (int i = 0; i < heroesArray.Length - 1; i++)
            {
                for (int j = 0; j < heroesArray.Length - i - 1; j++)
                {
                    // Порівнюємо два імена
                    if (string.Compare(heroesArray[j].Comics, heroesArray[j + 1].Comics,
                        StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Hero temp = heroesArray[j];
                        heroesArray[j] = heroesArray[j + 1];
                        heroesArray[j + 1] = temp;
                    }
                }
            }

            foreach (var comics in heroesArray)
            {
                Console.WriteLine($"- {comics.Comics}");
            }
        }
       SortWithCustomBubbleSort();
        static void nameANDdateBYdate()
        {
            Hero[] herosArray = _heroes.ToArray();
            for(int i=0; i<herosArray.Length-1; i++)
            {
                for(int j=0; j<herosArray.Length-i-1; j++)
                {
                    if (herosArray[j].YearOfBirth <herosArray[j+1].YearOfBirth)
                    {
                        Hero temp = herosArray[j];
                        herosArray[j] = herosArray[j+1];
                        herosArray[j + 1] = temp;
                    }
                }
            }
            foreach(var hero in herosArray)
                            {
                Console.WriteLine($"Name: {hero.Name}, YearOfBirth: {hero.YearOfBirth}");
            }
        }
        nameANDdateBYdate();
    }
    static void Declarative()
    {
        static void FindHeroesByYearOfBirth()
        {
            var herosyyear= _heroes
                .Where(hero => hero.YearOfBirth == 1941);
            foreach (var hero in herosyyear)
            {
              Console.WriteLine($"Name: {hero.Name}");
            }

        }
        FindHeroesByYearOfBirth();
        static void comicsbyalphabet()
        {
            var comicssbyalphabet = _heroes
                .OrderBy(comics => comics.Comics);
            foreach(var comics in comicssbyalphabet)
            {
                Console.WriteLine($" - {comics.Comics}");
            }
        }
        comicsbyalphabet();
        static void nameANDdateBYdate()
        {
            var bydate= _heroes
                .OrderByDescending(date=>date.YearOfBirth);
            foreach(var date in bydate)
            {
                Console.WriteLine($"Name: {date.Name}, YearOfBirth: {date.YearOfBirth}");
            }
        }
        nameANDdateBYdate();
    }

}







   