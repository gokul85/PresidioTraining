using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Interfaces
{
    public interface IPizzaServices
    {
        public Task<Pizza> AddPizzaAsync(Pizza pizza);
        public Task<Pizza> DeletePizzaAsync(int pizzaid);
        public Task<List<Pizza>> GetAllPizzaAsync();
    }
}
