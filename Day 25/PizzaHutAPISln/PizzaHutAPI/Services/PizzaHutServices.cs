using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.services
{
    public class PizzaHutServices : IPizzaHutServices
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaHutServices(IRepository<int, Pizza> reposiroty)
        {
            _repository = reposiroty;
        }

        public async Task<Pizza> DeletePizzaById(int id)
        {
            var pizza = await _repository.Delete(id);
            if(pizza != null)
            {
                return pizza;
            }
            throw new NoPizzaFoundException();
        }

        public async Task<IEnumerable<Pizza>> GetAllPizza()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() == 0)
                throw new NoPizzaFoundException();
            return pizzas;
        }

        public async Task<IEnumerable<Pizza>> GetAvailablePizza()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() != 0)
            {
                var availablePizza = pizzas.Where(piz => piz.Stocks > 0);
                return availablePizza;
            }
            throw new NoPizzaFoundException();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _repository.Get(id);
            if (pizza != null)
            {
                return pizza;
            }
            throw new NoPizzaFoundException();
        }

        public async Task<Pizza> GetPizzaByName(string name)
        {
            var pizzas = await _repository.Get();
            var pizza = pizzas.FirstOrDefault(p => p.Name == name);
            if(pizza != null)
            {
                return pizza;
            }
            throw new NoPizzaFoundException();
        }

        public async Task<Pizza> UpdatePizza(Pizza pizza)
        {
            var Updatedpizza = await _repository.Update(pizza);
            if (pizza != null) 
            { 
                return Updatedpizza;
            }
            throw new NoPizzaFoundException();
        }

    }
}
