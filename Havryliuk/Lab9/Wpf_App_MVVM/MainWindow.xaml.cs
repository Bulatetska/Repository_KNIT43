using System.Windows;

namespace SimpleWPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            
            // Фокус на текстовому полі при запуску
            Loaded += (s, e) => NameTextBox.Focus();
        }
    }
}