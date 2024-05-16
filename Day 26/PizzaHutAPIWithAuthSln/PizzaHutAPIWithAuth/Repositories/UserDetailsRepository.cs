using Microsoft.EntityFrameworkCore;
using PizzaHutAPIWithAuth.Contexts;
using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;
using System.Linq.Expressions;

namespace PizzaHutAPIWithAuth.Repositories
{
    public class UserDetailsRepository : IRepository<int, UserDetails>
    {
        private readonly PizzaHutContext _context;
        public UserDetailsRepository(PizzaHutContext context)
        {
            _context = context;
        }
        public async Task<UserDetails> Add(UserDetails item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserDetails> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserDetailsNotFoundException("User Details Not Found");
        }

        public async Task<UserDetails> Get(int key)
        {
            return await _context.UserDetails.FirstOrDefaultAsync(u => u.UserId == key);
        }

        public async Task<IEnumerable<UserDetails>> Get()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<IEnumerable<UserDetails>> FindAsync(Expression<Func<UserDetails, bool>> predicate)
        {
            return await _context.UserDetails.Where(predicate).ToListAsync();
        }

        public async Task<UserDetails> Update(UserDetails item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserDetailsNotFoundException("User Details Not Found");
        }
    }
}
