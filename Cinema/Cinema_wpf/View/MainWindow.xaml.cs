using System.Windows;
using Cinema_wpf.ViewModel; 

namespace Cinema_wpf.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            DataContext = new MainViewModel();
        }
    }
}