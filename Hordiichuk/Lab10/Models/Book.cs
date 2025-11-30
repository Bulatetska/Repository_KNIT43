using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab10.Models
{
    public class Book : INotifyPropertyChanged
    {
        private string title = "";
        private string author = "";
        private int year;

        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get => author;
            set { author = value; OnPropertyChanged(); }
        }

        public int Year
        {
            get => year;
            set { year = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
