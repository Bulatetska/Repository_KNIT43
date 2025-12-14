using System;
using System.Collections.Generic;
using System.Linq;

class Superhero
{
    public string Name { get; set; }
    public int BirthYear { get; set; }
    public string Comic { get; set; }
}

class Program
{
    static void Main()
    {
        List<Superhero> superheroes = new List<Superhero>
        {
            new Superhero { Name = "Batman", BirthYear = 1939, Comic = "DC" },
            new Superhero { Name = "Superman", BirthYear = 1938, Comic = "DC" },
            new Superhero { Name = "Captain America", BirthYear = 1941, Comic = "Marvel" },
            new Superhero { Name = "Spider-Man", BirthYear = 1962, Comic = "Marvel" },
            new Superhero { Name = "Wonder Woman", BirthYear = 1941, Comic = "DC" }
        };

        // ----------------------------
        // Завдання 1: Імена супергероїв, які народилися 1941 р.
        // ----------------------------
        Console.WriteLine("=== Завдання 1: Імена супергероїв, які народилися 1941 р. ===\n");

        Console.WriteLine("Імперативний підхід:");
        foreach (var hero in superheroes)
        {
            if (hero.BirthYear == 1941)
            {
                Console.WriteLine(hero.Name);
            }
        }

        Console.WriteLine("\nДекларативний (LINQ) підхід:");
        var heroes1941 = superheroes.Where(h => h.BirthYear == 1941);
        foreach (var hero in heroes1941)
        {
            Console.WriteLine(hero.Name);
        }

        // ----------------------------
        // Завдання 2: Назви коміксів, відсортовані в алфавітному порядку
        // ----------------------------
        Console.WriteLine("\n=== Завдання 2: Назви коміксів, відсортовані в алфавітному порядку ===\n");

        Console.WriteLine("Імперативний підхід:");
        List<string> comics = new List<string>();
        foreach (var hero in superheroes)
        {
            if (!comics.Contains(hero.Comic))
            {
                comics.Add(hero.Comic);
            }
        }
        comics.Sort();
        foreach (var comic in comics)
        {
            Console.WriteLine(comic);
        }

        Console.WriteLine("\nДекларативний (LINQ) підхід:");
        var sortedComics = superheroes.Select(h => h.Comic).Distinct().OrderBy(c => c);
        foreach (var comic in sortedComics)
        {
            Console.WriteLine(comic);
        }

        // ----------------------------
        // Завдання 3: Імена супергероїв та дати народження, відсортовані за спаданням дат народження
        // ----------------------------
        Console.WriteLine("\n=== Завдання 3: Імена супергероїв та дати народження, відсортовані за спаданням дат народження ===\n");

        Console.WriteLine("Імперативний підхід:");
        List<Superhero> sortedHeroes = new List<Superhero>(superheroes);
        sortedHeroes.Sort((h1, h2) => h2.BirthYear.CompareTo(h1.BirthYear));
        foreach (var hero in sortedHeroes)
        {
            Console.WriteLine($"{hero.Name} - {hero.BirthYear}");
        }

        Console.WriteLine("\nДекларативний (LINQ) підхід:");
        var sortedHeroesLINQ = superheroes.OrderByDescending(h => h.BirthYear);
        foreach (var hero in sortedHeroesLINQ)
        {
            Console.WriteLine($"{hero.Name} - {hero.BirthYear}");
        }
    }
}
