using ProductAPI.Models;
using ProductAPI.Repositories;
using System.Collections;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IReposiroty<int, Product> _productrepo;
        private readonly AzureStorageService _azureStorageService;

        public ProductService(IReposiroty<int, Product> productrepo, AzureStorageService azureStorageService)
        {
            _productrepo = productrepo;
            _azureStorageService = azureStorageService;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productrepo.Get();
            foreach (var product in products)
            {
                product.Image = _azureStorageService.GetBlobUrl(product.Image);
            }
            return products;
        }
    }
}
