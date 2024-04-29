using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Delete(int key)
        {
            Product product = await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            //Predicate<Product> findProduct =(p)=>p.Id==key;
            //Product product = items.ToList().Find(findProduct);

            //Product product = items.ToList().Find((p) => p.Id == key);

            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product != null)
            {
                return product;
            }
            throw new NoProductWithGiveIdException();
        }

        public override async Task<Product> Update(Product item)
        {
            Product product = await GetByKey(item.Id);
            if (product != null)
            {
                product = item;
            }
            return product;
        }
    }
}
