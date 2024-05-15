using PizzaHutAPI.Models;
using System.Numerics;

namespace PizzaHutAPI.Interfaces
{
    public interface IPizzaHutServices
    {
        public Task<IEnumerable<Pizza>> GetAllPizza();
        public Task<IEnumerable<Pizza>> GetAvailablePizza();
        public Task<Pizza> GetPizzaById(int id);
        public Task<Pizza> GetPizzaByName(string name);
        public Task<Pizza> DeletePizzaById(int id);
        public Task<Pizza> UpdatePizza(Pizza pizza);
    }
}
