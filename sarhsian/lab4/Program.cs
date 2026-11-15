using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabFourLinq
{
    internal static class Program
    {
        // Данні героїв взято з лекції «LINQ в C#».
        // Рік позначає рік першої появи у коміксах (умовний рік «народження» з лекції).
        private static readonly List<Hero> Heroes = new List<Hero>
        {
            new Hero("Superman", 1938, "Action Comics"),
            new Hero("Batman", 1938, "Detective Comics"),
            new Hero("Captain America", 1941, "Captain America Comics"),
            new Hero("Ironman", 1963, "Tales of Suspense"),
            new Hero("Spiderman", 1963, "Amazing Fantasy")
        };

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Лабораторна робота 4. LINQ в C#");
                Console.WriteLine("1. Завдання з лекції: 'man' в імені, сортування за іменем");
                Console.WriteLine("2. Герої, які з'явилися у 1941 році");
                Console.WriteLine("3. Назви коміксів за алфавітом");
                Console.WriteLine("4. Герої та роки, сортування за спаданням року");
                Console.WriteLine("5. Показати початковий список героїв");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть завдання: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": RunLectureExercise(); break;
                    case "2": RunTaskOne(); break;
                    case "3": RunTaskTwo(); break;
                    case "4": RunTaskThree(); break;
                    case "5": PrintSourceData(); break;
                    case "0": return;
                    default: Console.WriteLine("Невідоме завдання. Введіть число від 0 до 5."); break;
                }
            }
        }

        // Приклад із лекції: вибрати імена, що містять 'man', і відсортувати за алфавітом.
        private static void RunLectureExercise()
        {
            Console.WriteLine("ЗАВДАННЯ З ЛЕКЦІЇ: імена, що містять 'man'");

            Console.WriteLine("Імперативний підхід:");
            List<string> imperativeNames = new List<string>();
            foreach (Hero hero in Heroes)
            {
                if (hero.Name.Contains("man"))
                    imperativeNames.Add(hero.Name);
            }
            imperativeNames.Sort();
            foreach (string name in imperativeNames)
                Console.WriteLine(name);

            Console.WriteLine("\nДекларативний підхід (синтаксис запитів LINQ):");
            var declarativeNames =
                from hero in Heroes
                where hero.Name.Contains("man")
                orderby hero.Name
                select hero.Name;
            foreach (string name in declarativeNames)
                Console.WriteLine(name);

            Console.WriteLine("\nLINQ (синтаксис методів розширення):");
            var methodNames = Heroes
                .Where(hero => hero.Name.Contains("man"))
                .OrderBy(hero => hero.Name)
                .Select(hero => hero.Name);
            foreach (string name in methodNames)
                Console.WriteLine(name);
        }

        // Додаткове завдання 1: відбір за роком.
        private static void RunTaskOne()
        {
            Console.WriteLine("ЗАВДАННЯ 1: герої 1941 року");

            Console.WriteLine("Імперативний підхід:");
            List<string> imperativeNames = new List<string>();
            foreach (Hero hero in Heroes)
            {
                if (hero.YearOfBirth == 1941)
                    imperativeNames.Add(hero.Name);
            }
            foreach (string name in imperativeNames)
                Console.WriteLine(name);

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var declarativeNames =
                from hero in Heroes
                where hero.YearOfBirth == 1941
                select hero.Name;
            foreach (string name in declarativeNames)
                Console.WriteLine(name);
        }

        // Додаткове завдання 2: назви всіх коміксів у алфавітному порядку.
        private static void RunTaskTwo()
        {
            Console.WriteLine("ЗАВДАННЯ 2: комікси за алфавітом");

            Console.WriteLine("Імперативний підхід:");
            List<string> titles = new List<string>();
            foreach (Hero hero in Heroes)
                titles.Add(hero.Comics);
            titles.Sort();
            foreach (string title in titles)
                Console.WriteLine(title);

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var sortedTitles =
                from hero in Heroes
                orderby hero.Comics
                select hero.Comics;
            foreach (string title in sortedTitles)
                Console.WriteLine(title);
        }

        // Додаткове завдання 3: сортування за спаданням року збереженням порядку рівних років.
        private static void RunTaskThree()
        {
            Console.WriteLine("ЗАВДАННЯ 3: герої за спаданням року появи");
            Console.WriteLine("Примітка: у лекції наведено роки, а не повні календарні дати.");

            Console.WriteLine("\nІмперативний підхід:");
            List<Hero> sortedHeroes = new List<Hero>(Heroes);
            for (int i = 1; i < sortedHeroes.Count; i++)
            {
                Hero current = sortedHeroes[i];
                int j = i - 1;
                while (j >= 0 && sortedHeroes[j].YearOfBirth < current.YearOfBirth)
                {
                    sortedHeroes[j + 1] = sortedHeroes[j];
                    j--;
                }
                sortedHeroes[j + 1] = current;
            }
            foreach (Hero hero in sortedHeroes)
                Console.WriteLine($"{hero.Name} — {hero.YearOfBirth}");

            Console.WriteLine("\nДекларативний підхід (LINQ):");
            var declarativeHeroes =
                from hero in Heroes
                orderby hero.YearOfBirth descending
                select new { hero.Name, hero.YearOfBirth };
            foreach (var hero in declarativeHeroes)
                Console.WriteLine($"{hero.Name} — {hero.YearOfBirth}");
        }

        private static void PrintSourceData()
        {
            Console.WriteLine("ПОЧАТКОВІ ДАНІ З ЛЕКЦІЇ:");
            Console.WriteLine("Ім'я | Рік | Перший комікс");
            foreach (Hero hero in Heroes)
                Console.WriteLine($"{hero.Name} | {hero.YearOfBirth} | {hero.Comics}");
        }

        private sealed class Hero
        {
            public Hero(string name, int yearOfBirth, string comics)
            {
                Name = name;
                YearOfBirth = yearOfBirth;
                Comics = comics;
            }

            public string Name { get; }
            public int YearOfBirth { get; }
            public string Comics { get; }
        }
    }
}
