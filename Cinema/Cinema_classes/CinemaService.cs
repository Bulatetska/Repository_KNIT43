using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema_classes
{
    public class CinemaService
    {
        private List<Movie> Movies { get; } = new List<Movie>();
        private List<Hall> Halls { get; } = new List<Hall>();
        public List<Session> Sessions { get; } = new List<Session>();

        public User CurrentUser { get; private set; } = null!;

        public void Initialize()
        {
            CurrentUser = new User("Учасник В Тест", "test@cinema.com");

            var movie1 = new Movie("Інтерстеллар", 169, "Фантастика", "Подорож у космос.");
            var movie2 = new Movie("Дюна", 155, "Фантастика", "Пустельна планета.");

            Movies.Add(movie1);
            Movies.Add(movie2);

            var hallA = new Hall("Червоний", 5, 10);
            Halls.Add(hallA);

            Sessions.Add(new Session(movie1, hallA, DateTime.Now.AddHours(2), 100.00m));
            Sessions.Add(new Session(movie2, hallA, DateTime.Now.AddHours(5), 110.00m));

            Console.WriteLine("--- Система ініціалізована. ---");
        }

        public List<Session> GetAvailableSessions()
        {
            Console.WriteLine("\n--- ДОСТУПНІ СЕАНСИ ---");
            for (int i = 0; i < Sessions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Sessions[i]}");
            }
            Console.WriteLine("-------------------------");
            return Sessions;
        }

        public void ProcessBooking(User user, Session session, int row, int seatNum)
        {
            Console.WriteLine($"\n-> Спроба бронювання: {session.Movie.Title}, Місце {row}/{seatNum}...");

            bool bookingSuccessful = session.BookSeat(row, seatNum);

            if (bookingSuccessful)
            {
                Ticket newTicket = session.CreateTicket(row, seatNum);

                user.BuyTicket(newTicket);

                Console.WriteLine($"[Успіх!] Квиток: {newTicket.PrintTicket()}");
            }
            else
            {
                Console.WriteLine("[Помилка!] Місце вже заброньовано, або ви ввели неіснуючий ряд/номер.");
            }
        }
    }
}