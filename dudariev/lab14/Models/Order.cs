using System.ComponentModel.DataAnnotations;

namespace lab14.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
