using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Interfaces
{
    public interface IPizzaServices
    {
        public Task<Pizza> AddPizzaAsync(string pizzaname, decimal price, int stocks, string desc);
        public Task<Pizza> DeletePizzaAsync(int pizzaid);
        public Task<List<Pizza>> GetAllPizzaAsync();
    }
}
