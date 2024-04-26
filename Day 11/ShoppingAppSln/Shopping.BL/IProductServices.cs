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
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int productId);
        ICollection<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product GetProductByName(string name);
    }
}
