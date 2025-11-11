using System.Windows;

namespace BookAppMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BookViewModel();
        }
    }
}
