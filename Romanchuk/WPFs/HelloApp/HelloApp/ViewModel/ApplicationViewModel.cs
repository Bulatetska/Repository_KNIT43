using HelloApp.Model;
using HelloApp.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HelloApp.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private HelloName? newName;
        public ObservableCollection<HelloName> Names { get; set; }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    HelloName newName = new HelloName();
                    Names.Insert(0, newName);
                    NewName = newName;
                }));
            }
        }
        public HelloName? NewName
        {
            get { return newName; }
            set
            {
                newName = value;
                OnPropertyChanged("NewName");
            }
        }
        public ApplicationViewModel()
        {
            Names = new ObservableCollection<HelloName>();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}