using Cinema_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Linq;

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
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(); OnPropertyChanged(nameof(HeaderUserName)); }
        }

        public string HeaderUserName => CurrentUser != null ? CurrentUser.Name : "Мій кабінет";
        public string RegName { get; set; }
        public string RegEmail { get; set; }
        public string RegPhone { get; set; }

        public ObservableCollection<Ticket> ActiveTickets { get; set; } = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket> PastTickets { get; set; } = new ObservableCollection<Ticket>();

        public ObservableCollection<Session> Sessions { get; set; }
        public ObservableCollection<Seat> SelectedSeats { get; set; } = new ObservableCollection<Seat>();

        private List<Seat> _seats;
        public List<Seat> Seats
        {
            get => _seats;
            set { _seats = value; OnPropertyChanged(); }
        }

        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }
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
                    ShowBookingScreen();
                }
            }
        }

        private string _clientName;
        public string ClientName { get => _clientName; set { _clientName = value; OnPropertyChanged(); } }
        private string _clientPhone;
        public string ClientPhone { get => _clientPhone; set { _clientPhone = value; OnPropertyChanged(); } }

        public decimal TotalPrice => SelectedSeats.Sum(s => CalculatePrice(s));
        public string OrderSummary => GenerateOrderSummary();


        private Visibility _isRegistrationVisible = Visibility.Visible;
        public Visibility IsRegistrationVisible { get => _isRegistrationVisible; set { _isRegistrationVisible = value; OnPropertyChanged(); } }

        private Visibility _isListVisible = Visibility.Collapsed;
        public Visibility IsListVisible { get => _isListVisible; set { _isListVisible = value; OnPropertyChanged(); } }

        private Visibility _isBookingVisible = Visibility.Collapsed;
        public Visibility IsBookingVisible { get => _isBookingVisible; set { _isBookingVisible = value; OnPropertyChanged(); } }

        private Visibility _isCheckoutVisible = Visibility.Collapsed;
        public Visibility IsCheckoutVisible { get => _isCheckoutVisible; set { _isCheckoutVisible = value; OnPropertyChanged(); } }

        private Visibility _isProfileVisible = Visibility.Collapsed;
        public Visibility IsProfileVisible { get => _isProfileVisible; set { _isProfileVisible = value; OnPropertyChanged(); } }


        public ICommand RegisterCommand { get; }       
        public ICommand OpenProfileCommand { get; }    
        public ICommand BackToMoviesCommand { get; }   

        public ICommand GoBackToMoviesCommand { get; }
        public ICommand GoBackToBookingCommand { get; }
        public ICommand SelectSessionCommand { get; }
        public ICommand ToggleSeatCommand { get; }
        public ICommand ProceedToCheckoutCommand { get; }
        public ICommand ConfirmOrderCommand { get; }

        public MainViewModel()
        {
            GenerateData();
            RegisterCommand = new RelayCommand(o =>
            {
                if (string.IsNullOrWhiteSpace(RegName) || string.IsNullOrWhiteSpace(RegPhone))
                {
                    MessageBox.Show("Введіть ім'я та телефон!");
                    return;
                }
                CurrentUser = new User(RegName, RegEmail, RegPhone);
                ClientName = CurrentUser.Name;
                ClientPhone = CurrentUser.PhoneNumber;

                ShowListScreen();
            });
            OpenProfileCommand = new RelayCommand(o =>
            {
                if (CurrentUser == null) return;
                UpdateProfileLists(); 
                ShowProfileScreen();
            });

            BackToMoviesCommand = new RelayCommand(o => ShowListScreen());
            GoBackToMoviesCommand = new RelayCommand(o => ShowListScreen());

            GoBackToBookingCommand = new RelayCommand(o => ShowBookingScreen());

            SelectSessionCommand = new RelayCommand(param =>
            {
                if (param is Session session) SelectedSession = session;
            });

            ToggleSeatCommand = new RelayCommand(param =>
            {
                if (param is Seat seat && SelectedSession != null)
                {
                    if (seat.IsBooked) { MessageBox.Show("Це місце вже зайняте!"); return; }
                    seat.IsSelected = !seat.IsSelected;
                    if (seat.IsSelected) SelectedSeats.Add(seat); else SelectedSeats.Remove(seat);
                    OnPropertyChanged(nameof(TotalPrice));
                }
            });

            ProceedToCheckoutCommand = new RelayCommand(o =>
            {
                if (SelectedSeats.Count == 0) { MessageBox.Show("Оберіть місце!"); return; }
                OnPropertyChanged(nameof(OrderSummary));
                OnPropertyChanged(nameof(TotalPrice));
                ShowCheckoutScreen();
            });

            ConfirmOrderCommand = new RelayCommand(o => ConfirmOrder());
        }

        private void UpdateProfileLists()
        {
            ActiveTickets.Clear();
            PastTickets.Clear();

            if (CurrentUser == null) return;

            foreach (var ticket in CurrentUser.PurchaseHistory)
            {
                if (ticket.SessionDate > DateTime.Now)
                    ActiveTickets.Add(ticket);
                else
                    PastTickets.Add(ticket);
            }
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

        private void ConfirmOrder()
        {
            if (string.IsNullOrWhiteSpace(ClientName) || string.IsNullOrWhiteSpace(ClientPhone))
            {
                MessageBox.Show("Введіть дані!"); return;
            }

            foreach (var seat in SelectedSeats)
            {
            
                bool success = SelectedSession.BookSeat(seat.Row, seat.Number);
                if (success)
                {
                    var ticket = SelectedSession.CreateTicket(seat.Row, seat.Number);
                    CurrentUser.BuyTicket(ticket);
                }
                seat.IsSelected = false;
            }

            MessageBox.Show($"Дякуємо, {ClientName}!\nКвитки додано у ваш профіль.", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSeats.Clear();
            ShowListScreen();
        }

        private decimal CalculatePrice(Seat seat) => (seat.Type == SeatType.VIP) ? SelectedSession.price * 1.5m : SelectedSession.price;

        private string GenerateOrderSummary()
        {
            if (SelectedSession == null) return "";
            var sb = new StringBuilder();
            sb.AppendLine($"{SelectedSession.Movie.Title} | {SelectedSession.StartTime:dd.MM HH:mm}");
            sb.AppendLine($"Зал: {SelectedSession.Hall.Name}");
            foreach (var seat in SelectedSeats)
            {
                sb.AppendLine($"Ряд {seat.Row}, Місце {seat.Number} - {CalculatePrice(seat)} грн");
            }
            sb.AppendLine($"РАЗОМ: {TotalPrice} грн");
            return sb.ToString();
        }
        private void ResetVisibility()
        {
            IsRegistrationVisible = Visibility.Collapsed;
            IsListVisible = Visibility.Collapsed;
            IsBookingVisible = Visibility.Collapsed;
            IsCheckoutVisible = Visibility.Collapsed;
            IsProfileVisible = Visibility.Collapsed;
        }

        private void ShowRegistrationScreen()
        {
            ResetVisibility();
            IsRegistrationVisible = Visibility.Visible;
        }

        private void ShowListScreen()
        {
            ResetVisibility();
            IsListVisible = Visibility.Visible;
            SelectedSession = null;
        }

        private void ShowBookingScreen()
        {
            ResetVisibility();
            IsBookingVisible = Visibility.Visible;
        }

        private void ShowCheckoutScreen()
        {
            ResetVisibility();
            IsCheckoutVisible = Visibility.Visible;
        }

        private void ShowProfileScreen()
        {
            ResetVisibility();
            IsProfileVisible = Visibility.Visible;
        }

        private void GenerateData()
        {
            var redHall = new Hall("Червона Зала", 5, 8);
            var blueHall = new Hall("Синя Зала", 8, 12);
            var greenHall = new Hall("Зелена Зала", 6, 10);

            var dune = new Movie
            {Title = "Дюна 2",Genre = "Sci-Fi",DurationMinutes = 166,Description = "Епічна сага."};

            var kungfu = new Movie
            {Title = "Панда Кунг-Фу 4",Genre = "Мультфільм",DurationMinutes = 94,Description = "Пригоди По."};

            var godzilla = new Movie
            {Title = "Годзілла",Genre = "Екшн",DurationMinutes = 115,Description = "Битва титанів."};

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