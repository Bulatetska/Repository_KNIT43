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

            int startVipRow = Rows - 1;

            for (int r = 1; r <= Rows; r++)
            {
                bool isVipRow = (r >= startVipRow);
                int seatsInThisRow = isVipRow ? (SeatsPerRow / 2) : SeatsPerRow;
                SeatType type = isVipRow ? SeatType.VIP : SeatType.Standard;

                for (int n = 1; n <= seatsInThisRow; n++)
                {
                    seats.Add(new Seat(r, n, type));
                }
            }
            return seats;
        }
    }
}