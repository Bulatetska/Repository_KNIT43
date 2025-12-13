using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            price = price;
            Seats = hall.GenerateSeats();
        }

        public bool BookSeat(int row, int number)
        {
            var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);

            if (seat != null && !seat.IsBooked)
            {
                seat.Lock();
                return true;
            }
            return false;
        }

        public void CancelBooking(int row, int number)
        {
            var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
            if (seat != null && seat.IsBooked)
            {
                seat.Unlock();
            }
        }

        public bool IsSeatAvailable(int row, int number)
        {
            var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
            return seat != null && !seat.IsBooked;
        }


        public Ticket CreateTicket(int row, int number)
        {
            Seat seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);


            Ticket ticket;

            if (seat.Type == SeatType.VIP)
            {
                ticket = new VipTicket(price);
            }
            else
            {
                ticket = new StandartTicket(price);
            }

            ticket.MovieTitle = Movie.Title;
            ticket.HallName = Hall.Name;
            ticket.SessionDate = StartTime;
            ticket.Row = row;
            ticket.SeatNumber = number;

            return ticket;
        }
    }
}
