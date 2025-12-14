using System.Collections.Generic;

namespace Cinema_classes
{
    public class Hall
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }
        public List<Seat> Seats { get; set; }

        public Hall(string name, int rows, int seatsPerRow)
        {
            Name = name;
            Rows = rows;
            SeatsPerRow = seatsPerRow;
            Seats = GenerateSeats();
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
}