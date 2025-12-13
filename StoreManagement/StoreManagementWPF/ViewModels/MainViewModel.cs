using StoreManagement.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreManagementWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Store store;
        private readonly Customer customer;

        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Product> Cart { get; }

        private Product? selectedProduct;
        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public decimal Balance => customer.Balance;

        public ICommand BuyCommand { get; }

        public MainViewModel()
        {
            store = new Store();
            customer = new Customer("User", 200);

            AddDefaultProducts();

            Products = new ObservableCollection<Product>(store.Products);
            Cart = new ObservableCollection<Product>();

            BuyCommand = new RelayCommand(BuyProduct, CanBuyProduct);
        }

        private void AddDefaultProducts()
        {
            store.AddProduct(new Product("Milk", 30, 10));
            store.AddProduct(new Product("Bread", 25, 5));
            store.AddProduct(new Product("Eggs", 50, 30));
            store.AddProduct(new Product("Butter", 70, 15));
            store.AddProduct(new Product("Cheese", 120, 8));
            store.AddProduct(new Product("Apples", 40, 20));
            store.AddProduct(new Product("Bananas", 45, 18));
            store.AddProduct(new Product("Tomatoes", 35, 25));
            store.AddProduct(new Product("Potatoes", 20, 40));
            store.AddProduct(new Product("Chicken", 150, 12));
            store.AddProduct(new Product("Sugar", 32, 10));
            store.AddProduct(new Product("Tea", 60, 14));
        }

        private void BuyProduct()
        {
            if (SelectedProduct == null)
                return;

            bool success = store.BuyProduct(customer, SelectedProduct.Name);

            if (success)
            {
                Cart.Add(new Product(
                    SelectedProduct.Name,
                    SelectedProduct.Price,
                    1));

                OnPropertyChanged(nameof(Balance));
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanBuyProduct()
        {
            return SelectedProduct != null &&
                   SelectedProduct.Quantity > 0 &&
                   customer.Balance >= SelectedProduct.Price;
        }
    }
}
