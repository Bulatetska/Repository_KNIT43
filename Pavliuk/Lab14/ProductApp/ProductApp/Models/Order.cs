using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Product { get; set; } 
        public DateTime DateOrder { get; set; } = DateTime.Now;
        public int OrderStatus { get; set; } = 0;
        public int ProductId { get; set; }  
        public int Product_num { get; set; }

    }
}
