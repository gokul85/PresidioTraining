namespace PizzaHutAPIWithAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string  Image { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? Role { get; set; }
    }
}
