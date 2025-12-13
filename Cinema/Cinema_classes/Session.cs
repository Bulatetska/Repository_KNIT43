using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema_classes
{
    public class Session : IBookable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime StartTime { get; set; }
        public decimal price { get; set; }
        public List<Seat> Seats { get; set; }

        public Session(Movie movie, Hall hall, DateTime startTime, decimal price)
        {
            Movie = movie;
            Hall = hall;
            StartTime = startTime;
            this.price = price;
            Seats = hall.GenerateSeats();
        }

        public bool BookSeat(int row, int number)
        {
            var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number && !s.IsBooked);
            if (seat != null)
            {
                seat.Lock();
                return true;
            }
            return false;
        }

        public void CancelBooking(int row, int number)
        {
            var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number && s.IsBooked);
            seat?.Unlock();
        }

        public bool IsSeatAvailable(int row, int number)
        {
            return Seats.Any(s => s.Row == row && s.Number == number && !s.IsBooked);
        }

        public Ticket CreateTicket(int row, int number)
        {
            Seat seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
            if (seat == null) return null;

            // Фабрика квитків: визначаємо тип квитка
            Ticket ticket = (seat.Type == SeatType.VIP)
                ? new VipTicket(this.price)
                : new StandartTicket(this.price);

            // Заповнення полів квитка
            ticket.MovieTitle = Movie.Title;
            ticket.HallName = Hall.Name;
            ticket.SessionDate = StartTime;
            ticket.Row = row;
            ticket.SeatNumber = number;

            return ticket;
        }

        public override string ToString() => $"{Movie.Title} | Зал: {Hall.Name} | {StartTime:dd.MM HH:mm} | Ціна: {price:C}";
    }
}
