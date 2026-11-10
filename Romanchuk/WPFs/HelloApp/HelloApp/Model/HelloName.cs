using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace HelloApp.Model
{
    public class HelloName
    {
        private string? name;
        private string? namePlusHello;

        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                namePlusHello = $"Hello, {value}!";
                OnPropertyChanged("Name");
                OnPropertyChanged("NamePlusHello");
            }
        }

        public string? NamePlusHello
        {
            get { return namePlusHello; }
            set
            {
                namePlusHello = value;
                OnPropertyChanged("NamePlusHello");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
