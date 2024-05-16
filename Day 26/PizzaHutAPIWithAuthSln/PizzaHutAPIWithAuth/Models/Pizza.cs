namespace PizzaHutAPIWithAuth.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stocks { get; set; }
    }
}
