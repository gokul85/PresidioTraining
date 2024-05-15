using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }
}
