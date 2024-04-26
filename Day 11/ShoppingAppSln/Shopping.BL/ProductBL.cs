using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL
{
    public class ProductBL : IProductServices
    {
        readonly IRepository<int, Product> _productRepository;
        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public Product CreateProduct(Product product)
        {
            try
            {
                _productRepository.GetByKey(product.Id);
            }
            catch(NoProductWithGiveIdException exp)
            {
                return _productRepository.Add(product);
            }
            throw new ProductAlreadyExistsException();
        }

        public Product DeleteProduct(int productId)
        {
            try
            {
                Product productToDelete = _productRepository.GetByKey(productId);
            }
            catch(NoProductWithGiveIdException ex)
            {
                throw new NoProductWithGiveIdException();
            }
            return _productRepository.Delete(productId);
        }

        public ICollection<Product> GetAllProducts()
        {
            var products =_productRepository.GetAll();
            if (products.Any())
            {
                return products;
            }
            throw new NoProductFoundException();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetByKey(productId);
        }

        public Product GetProductByName(string name)
        {
            ICollection<Product> products = _productRepository.GetAll();
            Product productItems = products.FirstOrDefault(p => p.Name == name);
            if (productItems != null)
            {
                return productItems;
            }
            throw new NoProductFoundException();
        }

        public Product UpdateProduct(Product product)
        {
            Product existingProduct = _productRepository.GetByKey(product.Id);
            return _productRepository.Update(product);
        }
    }
}
