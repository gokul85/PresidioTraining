using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IReposiroty<int, Request>
    {
        private RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Remove(request);
                await _context.SaveChangesAsync();
                return request;
            }
            throw new Exception("No Request Found with the given ID");
        }

        public async Task<Request> Get(int key)
        {
            return (await _context.Requests.FirstOrDefaultAsync(r => r.RequestNumber == key)) ?? throw new Exception("No Request Found with the given ID");
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return (await _context.Requests.ToListAsync());
        }

        public async Task<Request> Update(Request item)
        {
            var request = await Get(item.RequestNumber);
            if (request != null)
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
                return request;
            }
            throw new Exception("No Request Found with the given ID");
        }
    }
}
