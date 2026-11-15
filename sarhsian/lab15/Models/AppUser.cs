using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.Models;

public class AppUser
{
    public int Id { get; set; }
    [Required, StringLength(80)]
    public string Name { get; set; } = "";
    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = "";
    [Required]
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "User";
    public ICollection<PurchaseOrder> Orders { get; set; } = new List<PurchaseOrder>();
}
