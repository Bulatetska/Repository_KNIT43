namespace Cinema_classes
{
    public class Seat
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatType Type { get; set; }
        public bool IsBooked { get; private set; } = false;

        public Seat(int row, int number, SeatType type)
        {
            Row = row;
            Number = number;
            Type = type;
        }

        public void Lock() => IsBooked = true;
        public void Unlock() => IsBooked = false;

        public override string ToString()
        {
            return $"Ряд {Row}, Місце {Number} ({Type}) - {(IsBooked ? "Зайнято" : "Вільно")}";
        }
    }
}