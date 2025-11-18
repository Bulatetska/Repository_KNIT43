using System.ComponentModel.DataAnnotations;

namespace MvcStoreLab.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я користувача є обов'язковим")]
        [Display(Name = "Ім'я користувача")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль є обов'язковим")]
        public string Password { get; set; }
    }
}