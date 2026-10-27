using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PshavaNET_lab10
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _userName = string.Empty;
        private string _greeting = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            //Встановлюємо джерело привязки даних
            DataContext = this;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Greeting
        {
            get => _greeting;
            set
            {
                if (_greeting != value)
                {
                    _greeting = value;
                    OnPropertyChanged();
                }
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                Greeting = "Будь ласка, введіть своє ім'я.";
                return;
            }

            Greeting = $"Привіт, {UserName.Trim()}!";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}