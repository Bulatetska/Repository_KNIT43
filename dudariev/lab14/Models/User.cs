using System.ComponentModel.DataAnnotations;

namespace lab14.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50), MinLength(3)]
        public required string Name { get; set; }
        [StringLength(100), MinLength(8)]
        public required string Password { get; set; }
        public required bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
