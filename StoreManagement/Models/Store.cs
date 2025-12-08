using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Models
{
    public class Store
    {
        public List<Product> Products { get; set; } = new();

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public Product? FindProduct(string name)
        {
            return Products.FirstOrDefault(p => p.Name == name);
        }

        public bool BuyProduct(Customer customer, string productName)
        {
            var product = FindProduct(productName);

            if (product == null || product.Quantity == 0)
                return false;

            if (customer.Balance < product.Price)
                return false;

            product.Quantity--;
            customer.Balance -= product.Price;
            customer.Cart.Add(new Product(product.Name, product.Price, 1));

            return true;
        }
    }
}