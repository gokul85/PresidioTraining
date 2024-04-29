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
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                await _productRepository.GetByKey(product.Id);
            }
            catch (NoProductWithGiveIdException exp)
            {
                return await _productRepository.Add(product);
            }
            throw new ProductAlreadyExistsException();
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            try
            {
                Product productToDelete = await _productRepository.GetByKey(productId);
            }
            catch (NoProductWithGiveIdException ex)
            {
                throw new NoProductWithGiveIdException();
            }
            return await _productRepository.Delete(productId);
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            if (products.Any())
            {
                return products;
            }
            throw new NoProductFoundException();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetByKey(productId);
        }

        public async Task<Product> GetProductByName(string name)
        {
            ICollection<Product> products = await _productRepository.GetAll();
            Product productItems = products.FirstOrDefault(p => p.Name == name);
            if (productItems != null)
            {
                return productItems;
            }
            throw new NoProductFoundException();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            Product existingProduct = await _productRepository.GetByKey(product.Id);
            return await _productRepository.Update(product);
        }
    }
}
