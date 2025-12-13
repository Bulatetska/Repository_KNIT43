using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StoreManagement.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int quantity;

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
