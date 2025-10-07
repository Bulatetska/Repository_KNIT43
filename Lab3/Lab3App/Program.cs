using System;
using System.Collections.Generic;  // Дозволяє використовувати колекції типу List<T>
using System.Linq;                 // Підключення LINQ — для запитів до колекцій

namespace Lab3App{
    class Program
    {
        // клас супергероя який має імя рік народження і комікс
        private class Hero
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
            public string Comics { get; set; }
        }

        // список героїв з початковими даними
        private static readonly List<Hero> _heroes = new List<Hero>
        {
            new Hero { Name = "Superman", YearOfBirth = 1932, Comics = "Action Comics" },
            new Hero { Name = "Batman", YearOfBirth = 1938, Comics = "Detective Comics" },
            new Hero { Name = "Captain America", YearOfBirth = 1941, Comics = "Captain America Comics" },
            new Hero { Name = "Ironman", YearOfBirth = 1973, Comics = "Tales of Suspense" },
            new Hero { Name = "Spiderman", YearOfBirth = 1968, Comics = "Amazing Fantasy" }
        };

        static void Main(string[] args)
        {
            // виводимо назву лабораторної
            Console.WriteLine("ЛАБОРАТОРНА з LINQ");
            Console.WriteLine("початковий список героїв:");
            foreach (var hero in _heroes)
            {
                // виводимо кожного героя
                Console.WriteLine($"{hero.Name} ({hero.YearOfBirth}) - {hero.Comics}");
            }

            // завдання 1 знайти героїв які народились у 1941 році
            Console.WriteLine("\n Завдання 1. Герої 1941 року");
            
            // імперативний підхід тобто звичайний ручний метод без linq
            Console.WriteLine("\nІмперативний підхід:");
            var heroes1941 = new List<string>();
            foreach (var hero in _heroes)
            {
                // перевіряємо якщо рік народження 1941 тоді додаємо в список
                if (hero.YearOfBirth == 1941)
                {
                    heroes1941.Add(hero.Name);
                }
            }
            // виводимо результат
            foreach (var heroName in heroes1941)
            {
                Console.WriteLine(heroName);
            }

            // декларативний підхід з використанням linq
            Console.WriteLine("\nДекларативний підхід (LINQ) ");
            var heroes1941Linq = from hero in _heroes
                                where hero.YearOfBirth == 1941
                                select hero.Name;
            foreach (var heroName in heroes1941Linq)
            {
                Console.WriteLine(heroName);
            }

            // завдання 2 отримати всі назви коміксів в алфавітному порядку
            Console.WriteLine("\nЗавдання 2. Комікси в алфавітному порядку");
            
            // імперативний варіант спочатку збираємо комікси без повторів потім сортуємо
            Console.WriteLine("\nІмперативний підхід:");
            var comics = new List<string>();
            foreach (var hero in _heroes)
            {
                // перевіряємо щоб не додавати однакові комікси
                if (!comics.Contains(hero.Comics))
                {
                    comics.Add(hero.Comics);
                }
            }
            // сортуємо список
            comics.Sort();
            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }

            // декларативний підхід через linq набагато коротше
            Console.WriteLine("\nДекларативний підхід (LINQ)");
            var comicsLinq = (from hero in _heroes
                             orderby hero.Comics
                             select hero.Comics).Distinct();
            foreach (var comic in comicsLinq)
            {
                Console.WriteLine(comic);
            }

            // завдання 3 показати імена та роки народження у порядку спадання
            Console.WriteLine("\nЗавдання 3. Імена та дати народження в порядку спадання");
            
            // імперативний підхід робимо список кортежів і сортуємо вручну
            Console.WriteLine("\nІмперативний підхід:");
            var heroInfo = new List<(string Name, int Year)>();
            foreach (var hero in _heroes)
            {
                heroInfo.Add((hero.Name, hero.YearOfBirth));
            }
            // сортуємо за роком народження від більшого до меншого
            heroInfo.Sort((x, y) => y.Year.CompareTo(x.Year));
            foreach (var info in heroInfo)
            {
                Console.WriteLine($"{info.Name} - {info.Year}");
            }

            // декларативний варіант через linq виглядає чистіше
            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var heroInfoLinq = from hero in _heroes
                              orderby hero.YearOfBirth descending
                              select new { hero.Name, hero.YearOfBirth };
            foreach (var info in heroInfoLinq)
            {
                Console.WriteLine($"{info.Name} - {info.YearOfBirth}");
            }

        }
    }
}


//Декларативний підхід (LINQ) — це коли ми кажемо, що потрібно зробити, а не як саме це робити.
//Ми описуємо "умови та результат", а всю роботу виконує сам механізм LINQ.

//Імперативний підхід  це коли ми "по кроках" описуємо, як саме отримати результат.
//Ми самі створюємо цикли, перевірки, списки й керуємо кожним етапом виконання.
//Імперативний типу "як зробити" (покрокові дії).
//Декларативний типу "що зробити" (опис результату).
