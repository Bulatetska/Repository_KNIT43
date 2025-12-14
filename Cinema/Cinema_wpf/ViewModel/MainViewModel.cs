using Cinema_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Cinema_wpf.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged;
    }

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Session> Sessions { get; set; }

        private Session _selectedSession;
        public Session SelectedSession
        {
            get => _selectedSession;
            set
            {
                _selectedSession = value;
                OnPropertyChanged();
                if (_selectedSession != null)
                {
                    LoadSeatsForSession();
                    IsBookingVisible = Visibility.Visible;
                    IsListVisible = Visibility.Collapsed;
                }
            }
        }

        private List<Seat> _seats;
        public List<Seat> Seats
        {
            get => _seats;
            set { _seats = value; OnPropertyChanged(); }
        }

        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }

        private Visibility _isListVisible = Visibility.Visible;
        public Visibility IsListVisible
        {
            get => _isListVisible;
            set { _isListVisible = value; OnPropertyChanged(); }
        }

        private Visibility _isBookingVisible = Visibility.Collapsed;
        public Visibility IsBookingVisible
        {
            get => _isBookingVisible;
            set { _isBookingVisible = value; OnPropertyChanged(); }
        }

        public ICommand GoBackCommand { get; }
        public ICommand OpenProfileCommand { get; }

        public ICommand SelectSessionCommand { get; }

        public MainViewModel()
        {
            GenerateData();
            GoBackCommand = new RelayCommand(o => GoBack());
            OpenProfileCommand = new RelayCommand(o => MessageBox.Show("Кабінет в розробці"));

            SelectSessionCommand = new RelayCommand(param =>
            {
                if (param is Session session)
                {
                    SelectedSession = session;
                }
            });
        }

        private void GoBack()
        {
            IsBookingVisible = Visibility.Collapsed;
            IsListVisible = Visibility.Visible;
            SelectedSession = null;
        }

        private void LoadSeatsForSession()
        {
            if (SelectedSession == null) return;
            Seats = SelectedSession.Seats;
            RowsCount = SelectedSession.Hall.Rows;
            ColumnsCount = SelectedSession.Hall.SeatsPerRow;
            OnPropertyChanged(nameof(RowsCount));
            OnPropertyChanged(nameof(ColumnsCount));
        }

        private void GenerateData()
        {

            var redHall = new Hall("Червона Зала", 5, 8);
            var blueHall = new Hall("Синя Зала", 8, 12);
            var greenHall = new Hall("Зелена Зала", 6, 10);

            var dune = new Movie { Title = "Дюна 2", Genre = "Sci-Fi", DurationMinutes = 166, Description = "Епічна сага." };
            var kungfu = new Movie { Title = "Панда Кунг-Фу 4", Genre = "Мультфільм", DurationMinutes = 94, Description = "Пригоди По." };
            var godzilla = new Movie { Title = "Годзілла", Genre = "Екшн", DurationMinutes = 115, Description = "Битва титанів." };

            Sessions = new ObservableCollection<Session>
            {
                new Session(dune, redHall, DateTime.Now.AddHours(1), 150),
                new Session(kungfu, blueHall, DateTime.Now.AddHours(2), 120),
                new Session(godzilla, greenHall, DateTime.Now.AddHours(3), 140),
                new Session(dune, blueHall, DateTime.Now.AddHours(5), 200),
                new Session(kungfu, greenHall, DateTime.Now.AddHours(6), 120),
                new Session(godzilla, redHall, DateTime.Now.AddHours(7), 140),
                new Session(dune, greenHall, DateTime.Now.AddDays(1).AddHours(10), 150),
                new Session(kungfu, redHall, DateTime.Now.AddDays(1).AddHours(12), 120),
                new Session(godzilla, blueHall, DateTime.Now.AddDays(1).AddHours(14), 200)
            };
        }
    }
}