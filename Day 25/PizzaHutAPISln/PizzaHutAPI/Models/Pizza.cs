using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stocks { get; set; }
        public string size { get; set; }
    }
}
