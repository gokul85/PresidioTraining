namespace PizzaHutAPIWithAuth.Models.DTOs
{
    public class UserRegisterDTO : User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
