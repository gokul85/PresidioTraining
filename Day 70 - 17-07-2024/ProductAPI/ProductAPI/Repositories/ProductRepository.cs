using Microsoft.EntityFrameworkCore;
using ProductAPI.Contexts;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IReposiroty<int, Product>
    {
        private readonly ProductAPIContext _context;

        public ProductRepository(ProductAPIContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int key)
        {
            return await _context.Products.FirstOrDefaultAsync(r => r.Id == key) ?? throw new Exception("No Product Found with the given ID");
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
