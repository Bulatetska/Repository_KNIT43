using System.Windows;
using BookManagementApp.ViewModels;

namespace BookManagementApp.Views
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