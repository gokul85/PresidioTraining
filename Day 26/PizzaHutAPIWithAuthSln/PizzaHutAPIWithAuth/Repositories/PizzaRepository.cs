using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaHutAPIWithAuth.Contexts;
using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;
using System.Linq.Expressions;

namespace PizzaHutAPIWithAuth.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaHutContext _context;
        public PizzaRepository(PizzaHutContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new PizzaNotFoundException("Pizza Not Found");
        }

        public async Task<IEnumerable<Pizza>> FindAsync(Expression<Func<Pizza, bool>> predicate)
        {
            return await _context.Pizzas.Where(predicate).ToListAsync();
        }

        public async Task<Pizza> Get(int key)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(u => u.PizzaId == key);
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if (pizza != null)
            {
                _context.Update(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new PizzaNotFoundException("Pizza Not Found");
        }
    }
}
