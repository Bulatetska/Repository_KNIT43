using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.ViewModels;

public class RegisterModel
{
    [Required(ErrorMessage = "Введіть ім'я.")]
    [StringLength(80)]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Введіть email.")]
    [EmailAddress(ErrorMessage = "Некоректна електронна адреса.")]
    public string Email { get; set; } = "";
    [Required, MinLength(6, ErrorMessage = "Пароль повинен містити щонайменше 6 символів.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
