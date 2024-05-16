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
        public async Task<Pizza> AddPizzaAsync(Pizza pizza)
        {
            await _pizzarepo.Add(pizza);
            return pizza;
        }

        public async Task<Pizza> DeletePizzaAsync(int pizzaid)
        {
            try
            {
                var pizza = await _pizzarepo.Get(pizzaid);
                await _pizzarepo.Delete(pizzaid);
                return pizza;
            } catch (Exception ex) {
                throw new PizzaNotFoundException("No Pizza Found");
            }
            
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
