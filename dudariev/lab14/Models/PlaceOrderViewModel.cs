using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace lab14.Models
{
    public class PlaceOrderViewModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
