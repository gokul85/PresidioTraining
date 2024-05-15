using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId {  get; set; }
        public DateTime OrderTime { get; set; }= DateTime.Now;
        public decimal totalOrderPrice { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
