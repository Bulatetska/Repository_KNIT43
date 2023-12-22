using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            FizzBuzz();

            // task 2
            DisplayPeopleInfo();

            // task 3
            DisplayFullNameAndInitials();
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("кратне трьом і п’яти");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("кратне трьом");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("кратне п’яти");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }

        static void DisplayPeopleInfo()
        {
            string[] people = {
                "Пушкін Олександр Сергійович",
                "Шевченко Тарас Григорович"
            };

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        static void DisplayFullNameAndInitials()
        {
            string[] people = {
                "Пушкін Олександр Сергійович",
                "Шевченко Тарас Григорович"
            };

            foreach (var fullPersonName in people)
            {
                string[] nameParts = fullPersonName.Split(' ');
                string initials = $"{nameParts[0]} {nameParts[1].Substring(0, 1)}. {nameParts[2].Substring(0, 1)}.";
                Console.WriteLine(initials);
            }
            Console.WriteLine();
        }
    }
}
