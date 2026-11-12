using System.Windows;
using LabElevenMvvm.ViewModels;

namespace LabElevenMvvm
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
