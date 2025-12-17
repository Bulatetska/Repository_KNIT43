using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace indz
{
    public class User : IBorrower<User, Book>, INotifyPropertyChanged
    {
        public required string Name { get; set; }

        public IBorrower<User, Book> AsIBorrower { get => this; }
        public ObservableCollection<Book> Borrowed { get; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
