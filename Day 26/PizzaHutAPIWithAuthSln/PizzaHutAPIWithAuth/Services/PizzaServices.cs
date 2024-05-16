using PizzaHutAPIWithAuth.Contexts;
using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly IRepository<int, Pizza> _pizzarepo;
        public PizzaServices(IRepository<int, Pizza> pizzarepo)
        {
            _pizzarepo = pizzarepo;            
        }
        public Task<Pizza> AddPizzaAsync(string pizzaname, decimal price, int stocks, string desc)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> DeletePizzaAsync(int pizzaid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pizza>> GetAllPizzaAsync()
        {
            var pizzas = await _pizzarepo.Get();
            if (pizzas.Any())
            {
                return pizzas.ToList();
            }
            throw new NoPizzasFoundException("No Pizzas Found Exception");
        }
    }
}
