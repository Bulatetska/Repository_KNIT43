using StoreManagement.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreManagementWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public Product? SelectedProduct { get; set; }

        public ICommand BuyCommand { get; }

        private Store store = new Store();
        private Customer customer = new Customer("User", 200);

        public MainViewModel()
        {
            store.AddProduct(new Product("Milk", 30, 10));
            store.AddProduct(new Product("Bread", 20, 5));

            Products = new ObservableCollection<Product>(store.Products);
            Cart = new ObservableCollection<Product>();

            BuyCommand = new RelayCommand(Buy);
        }

        private void Buy()
        {
            if (SelectedProduct == null) return;

            if (store.BuyProduct(customer, SelectedProduct.Name))
                Cart.Add(new Product(SelectedProduct.Name, SelectedProduct.Price, 1));
        }
    }
}