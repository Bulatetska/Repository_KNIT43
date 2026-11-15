using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.ViewModels;

public class LoginModel
{
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
