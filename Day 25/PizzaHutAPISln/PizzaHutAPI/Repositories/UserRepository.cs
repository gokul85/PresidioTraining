using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.contexts;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaHutContext _context;
        public UserRepository(PizzaHutContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchUserException();
        }

        public Task<User> Get(int key)
        {
            var employee = _context.Users.FirstOrDefaultAsync(e => e.UserId == key);
            if (employee != null)
            {
                return employee;
            }
            throw new NoSuchUserException();
        }

        public async Task<IEnumerable<User>> Get()
        {
            var employees = await _context.Users.ToListAsync();
            return employees;
        }

        public async Task<User> Update(User item)
        {
            var employee = await Get(item.UserId);
            if (employee != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchUserException();
        }
    }
}
