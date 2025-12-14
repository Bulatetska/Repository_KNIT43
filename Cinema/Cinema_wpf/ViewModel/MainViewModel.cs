using System.Collections.Generic;
using Cinema_classes;

namespace Cinema_wpf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private Movie _currentMovie;
        public Movie CurrentMovie
        {
            get => _currentMovie;
            set { _currentMovie = value; OnPropertyChanged(); }
        }

        private List<Seat> _seats;
        public List<Seat> Seats
        {
            get => _seats;
            set { _seats = value; OnPropertyChanged(); }
        }

        
        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }

       
        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
           
            CurrentMovie = new Movie
            {
                Title = "Дюна: Частина Друга",
                DurationMinutes = 166,
                Genre = "Sci-Fi",
                Description = "Пол Атрід поєднується з Чані та фрименами..."
            };
           
            Hall hall = new Hall("Головний зал", 8, 10);

            RowsCount = hall.Rows;
            ColumnsCount = hall.SeatsPerRow;
            Seats = hall.Seats; 
        }
    }
}