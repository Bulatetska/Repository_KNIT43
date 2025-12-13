using System;
using System.Collections.Generic;
using System.Linq;

public enum SeatType { Standard, VIP }

public class Movie { public string Title { get; set; } }

public class Seat
{
    public int Row { get; }
    public int Number { get; }
    public SeatType Type { get; }
    public bool IsBooked { get; private set; } = false;

    public Seat(int row, int number, SeatType type)
    {
        Row = row;
        Number = number;
        Type = type;
    }

    public void Lock() => IsBooked = true;
}

public class Hall
{
    public string Name { get; set; }
    public int Rows { get; }
    public int SeatsPerRow { get; }

    public Hall(string name, int rows, int seatsPerRow)
    {
        Name = name;
        Rows = rows;
        SeatsPerRow = seatsPerRow;
    }

    public List<Seat> GenerateSeats()
    {
        var seats = new List<Seat>();
        for (int r = 1; r <= Rows; r++)
            for (int n = 1; n <= SeatsPerRow; n++)
                seats.Add(new Seat(r, n, (r == Rows) ? SeatType.VIP : SeatType.Standard));
        return seats;
    }
}

public interface IBookable
{
    bool BookSeat(int row, int num);
    Ticket CreateTicket(Seat seat);
}

public class Session : IBookable
{
    public Movie Movie { get; }
    public Hall Hall { get; }
    public DateTime StartTime { get; }
    public List<Seat> Seats { get; }

    public Session(Movie movie, Hall hall, DateTime startTime)
    {
        Movie = movie;
        Hall = hall;
        StartTime = startTime;
        Seats = hall.GenerateSeats();
    }

    public bool BookSeat(int row, int num)
    {
        var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == num && !s.IsBooked);
        if (seat != null)
        { 
            seat.Lock();
            return true;
        }
        return false;
    }

    public Ticket CreateTicket(Seat seat)
    {
        return seat.Type == SeatType.VIP
            ? new VipTicket(Movie.Title, $"{seat.Row}/{seat.Number}", 150)
            : new StandardTicket(Movie.Title, $"{seat.Row}/{seat.Number}", 100);
    }

    public override string ToString() => $"{Movie.Title} | Зал: {Hall.Name} | {StartTime:dd.MM HH:mm}";
}

public class CinemaService
{
    private List<Movie> Movies { get; } = new List<Movie>();
    private List<Hall> Halls { get; } = new List<Hall>();
    public List<Session> Sessions { get; } = new List<Session>();

    public User CurrentUser { get; private set; }

    public void Initialize()
    {
        CurrentUser = new User("Учасник В Тест", "test@cinema.com");
        var movie1 = new Movie { Title = "Інтерстеллар" };
        var movie2 = new Movie { Title = "Дюна" };
        Movies.Add(movie1);
        Movies.Add(movie2);
        var hallA = new Hall("Червоний", 5, 10);
        Halls.Add(hallA);

        Sessions.Add(new Session(movie1, hallA, DateTime.Now.AddHours(2)));
        Sessions.Add(new Session(movie2, hallA, DateTime.Now.AddHours(5)));

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

        public void ProcessBooking(User user, Session session, int row, int seatNum)
    {
        Console.WriteLine($"\n-> Спроба бронювання: {session.Movie.Title}, Місце {row}/{seatNum}...");

        bool bookingSuccessful = session.BookSeat(row, seatNum);

        if (bookingSuccessful)
        {
            Seat bookedSeat = session.Seats.First(s => s.Row == row && s.Number == seatNum);
            Ticket newTicket = session.CreateTicket(bookedSeat);
            user.BuyTicket(newTicket);

            Console.WriteLine($"[Успіх!] Квиток: {newTicket.PrintTicket()}");
        }
        else
        {
            Console.WriteLine("[Помилка!] Місце вже заброньовано, або ви ввели неіснуючий ряд/номер.");
        }
    }
}