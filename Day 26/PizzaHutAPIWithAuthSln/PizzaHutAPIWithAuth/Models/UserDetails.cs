using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPIWithAuth.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public string Status { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
