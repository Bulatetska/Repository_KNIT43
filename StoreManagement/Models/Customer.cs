using System.Collections.Generic;

namespace StoreManagement.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Product> Cart { get; set; } = new();
        public decimal Balance { get; set; }

        public Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public void AddToCart(Product product)
        {
            Cart.Add(product);
        }
    }
}
