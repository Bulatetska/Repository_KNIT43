namespace lab14.Models
{
    public class LoginViewModel
    {
        public string? ReturnUrl { get; set; }
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
