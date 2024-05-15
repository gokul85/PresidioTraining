using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.contexts;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Repositories
{
    public class UserDetailsRepository : IRepository<int, UserDetails>
    {
        private PizzaHutContext _context;

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
            throw new Exception("No user with the given ID");
        }

        public async Task<UserDetails> Get(int key)
        {
            return(await _context.UsersDetails.SingleOrDefaultAsync(u => u.UserId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IEnumerable<UserDetails>> Get()
        {
            return (await _context.UsersDetails.ToListAsync());
        }

        public async Task<UserDetails> Update(UserDetails item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
    }
}
