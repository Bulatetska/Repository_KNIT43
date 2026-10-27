using System.Windows;
using PshavaNET_lab11.ViewModels;

namespace PshavaNET_lab11
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