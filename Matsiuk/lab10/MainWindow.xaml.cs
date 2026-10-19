using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Lab10WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string userName = "";
        private string greetingMessage = "";

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public string GreetingMessage
        {
            get { return greetingMessage; }
            set
            {
                greetingMessage = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                GreetingMessage = "Please enter your name.";
            }
            else
            {
                GreetingMessage = $"Hello, {UserName}!";
            }
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