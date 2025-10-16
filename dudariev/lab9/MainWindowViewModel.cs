using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab9
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string name = "";
        private string message = "";
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
