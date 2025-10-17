using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab10
{
    internal class Book : INotifyPropertyChanged
    {
        private string title = "";
        private string author = "";
        private int year;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }
        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
