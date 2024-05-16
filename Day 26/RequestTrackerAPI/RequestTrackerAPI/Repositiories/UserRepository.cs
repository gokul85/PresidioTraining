using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerAPI.Contexts;
using RequestTrackerAPI.Exceptions;
using RequestTrackerAPI.Interfaces;
using RequestTrackerAPI.Models;

namespace RequestTrackerAPI.Repositiories
{
    public class UserRepository : IRepository<int, User>
    {
        public readonly RequestTrackerContext _context;
        public UserRepository(RequestTrackerContext context)
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
            throw new NoUserFoundExecption();
        }

        public async Task<User> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.EmployeeId == key);
            return user;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.EmployeeId);
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoUserFoundExecption();
        }
    }
}
