using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaHutAPIWithAuth.Contexts;
using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;
using System.Linq.Expressions;

namespace PizzaHutAPIWithAuth.Repositories
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
            var user = await Get(key);
            if(user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserNotFoundException("User Not Found");
        }

        public async Task<User> Get(int key)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == key);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }
        public async Task<User> Update(User item)
        {
            var user = await Get(item.Id);
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserNotFoundException("User Not Found");
        }
    }
}
