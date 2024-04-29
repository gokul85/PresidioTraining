using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL
{
    public interface IProductServices
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productId);
        Task<ICollection<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Product> GetProductByName(string name);
    }
}
