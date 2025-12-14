using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cinema_classes
{
    public class Seat : INotifyPropertyChanged
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatType Type { get; set; }
        public bool IsBooked { get; private set; } = false;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }

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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}