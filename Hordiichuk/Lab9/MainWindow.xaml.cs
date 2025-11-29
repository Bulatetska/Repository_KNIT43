using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MyWpfApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string userName = "";
        private string greetingMessage = "";

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public string GreetingMessage
        {
            get => greetingMessage;
            set
            {
                greetingMessage = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();   // тепер працює
            DataContext = this;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            GreetingMessage = $"Привіт, {UserName}!";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
