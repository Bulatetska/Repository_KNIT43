using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLab
{
    // Модель супергероя
    public class Superhero
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
    }

    // Модель коміксу
    public class Comic
    {
        public string Title { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // ----- Дані для всіх завдань -----
            var heroes = new List<Superhero>
            {
                new Superhero { Name = "Batman",          BirthYear = 1939 },
                new Superhero { Name = "Wonder Woman",    BirthYear = 1941 },
                new Superhero { Name = "Captain America", BirthYear = 1941 },
                new Superhero { Name = "Spider-Man",      BirthYear = 1962 },
                new Superhero { Name = "Iron Man",        BirthYear = 1963 }
            };

            var comics = new List<Comic>
            {
                new Comic { Title = "Detective Comics" },
                new Comic { Title = "Action Comics" },
                new Comic { Title = "Amazing Fantasy" },
                new Comic { Title = "Captain America Comics" }
            };

            // ----- Завдання 1 -----
            Console.WriteLine("=== Завдання 1: герої, народжені в 1941 р. ===");

            Console.WriteLine("\nІмперативний підхід:");
            Task1_Imperative(heroes);

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            Task1_Linq(heroes);


            // ----- Завдання 2 -----
            Console.WriteLine("\n\n=== Завдання 2: назви коміксів по алфавіту ===");

            Console.WriteLine("\nІмперативний підхід:");
            Task2_Imperative(comics);

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            Task2_Linq(comics);


            // ----- Завдання 3 -----
            Console.WriteLine("\n\n=== Завдання 3: імена героїв і роки народження (спадання) ===");

            Console.WriteLine("\nІмперативний підхід:");
            Task3_Imperative(heroes);

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            Task3_Linq(heroes);

            Console.WriteLine("\n\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        // =========================
        // 1. Герої, народжені у 1941
        // =========================

        // Імперативний стиль: цикли + if
        static void Task1_Imperative(List<Superhero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero.BirthYear == 1941)
                {
                    Console.WriteLine(hero.Name);
                }
            }
        }

        // Декларативний стиль: LINQ
        static void Task1_Linq(List<Superhero> heroes)
        {
            var born1941 = heroes
                .Where(h => h.BirthYear == 1941)
                .Select(h => h.Name);

            foreach (var name in born1941)
            {
                Console.WriteLine(name);
            }
        }

        // ============================================
        // 2. Назви коміксів, відсортовані по алфавіту
        // ============================================

        static void Task2_Imperative(List<Comic> comics)
        {
            // Спочатку зберемо всі назви в список рядків
            var titles = new List<string>();
            foreach (var comic in comics)
            {
                titles.Add(comic.Title);
            }

            // Відсортуємо стандартним методом
            titles.Sort();

            // Виведемо
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        static void Task2_Linq(List<Comic> comics)
        {
            var sortedTitles = comics
                .Select(c => c.Title)
                .OrderBy(t => t);

            foreach (var title in sortedTitles)
            {
                Console.WriteLine(title);
            }
        }

        // ==========================================================
        // 3. Імена супергероїв + рік народження, сорт. за спаданням
        // ==========================================================

        static void Task3_Imperative(List<Superhero> heroes)
        {
            // Зробимо копію, щоб не псувати вихідний список
            var copy = new List<Superhero>(heroes);

            // Сортуємо вручну за спаданням BirthYear
            copy.Sort((a, b) => b.BirthYear.CompareTo(a.BirthYear));

            foreach (var hero in copy)
            {
                Console.WriteLine($"{hero.Name} — {hero.BirthYear}");
            }
        }

        static void Task3_Linq(List<Superhero> heroes)
        {
            var sortedHeroes = heroes
                .OrderByDescending(h => h.BirthYear)
                .Select(h => new { h.Name, h.BirthYear });

            foreach (var h in sortedHeroes)
            {
                Console.WriteLine($"{h.Name} — {h.BirthYear}");
            }
        }
    }
}
