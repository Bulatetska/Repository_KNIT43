using System.ComponentModel;
using System.Windows;

namespace WpfAppGreeting
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string greeting;

        public string Greeting
        {
            get => greeting;
            set
            {
                greeting = value;
                OnPropertyChanged(nameof(Greeting));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Прив'язка даних
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Greeting = $"Привіт, {NameTextBox.Text}!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
