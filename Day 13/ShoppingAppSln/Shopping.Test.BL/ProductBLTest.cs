using Shopping.BL;
using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;
using System.Numerics;

namespace Shopping.Test.BL
{
    public class ProductBLTest
    {
        IRepository<int, Product> repository;
        IProductServices productServices;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);
            productServices = new ProductBL(repository);
        }

        [Test]
        public async Task CreateProductSuccessTest()
        {
            Product newProduct = new Product()
            {
                Id = 2,
                Name = "MilkiBar",
                Price = 12,
                QuantityInHand = 20,
            };
            //Action
            var result = await productServices.CreateProduct(newProduct);

            //Assert
            Assert.AreEqual(result.Id, newProduct.Id);
        }

        [Test]
        public async Task CreateProductExceptionTest()
        {
            //Arrange
            Product newProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };

            //Action
            var exception = Assert.ThrowsAsync<ProductAlreadyExistsException>(() => productServices.CreateProduct(newProduct));

            //Assert
            Assert.AreEqual("Product Already Exists", exception.Message);
        }

        [Test]
        public async Task DeleteProductSuccesTest()
        {
            //Action
            var result = await productServices.DeleteProduct(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task DeleteProductExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => productServices.DeleteProduct(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetProductsByIDSuccessTest()
        {
            //Action
            var result = await productServices.GetProductById(1);
            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetProductsByIDExceptionTest()
        {
            //Action
            await productServices.DeleteProduct(1);
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => productServices.GetProductById(1));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetProductsByNameSuccessTest()
        {
            //Action
            var result = await productServices.GetProductByName("KitKat");
            //Assert
            Assert.AreEqual("KitKat", result.Name);
        }

        [Test]
        public async Task GetProductsByNameExceptionTest()
        {
            //Action
            await productServices.DeleteProduct(1);
            var exception = Assert.ThrowsAsync<NoProductFoundException>(() => productServices.GetProductByName("DiaryMilk"));
            //Assert
            Assert.AreEqual("No Product Found", exception.Message);
        }

        [Test]
        public async Task UpdateProductSuccessTest()
        {
            //Arrange
            Product updatedProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 20,
                QuantityInHand = 5,
            };

            //Action
            var result = await productServices.UpdateProduct(updatedProduct);
            //Assert
            Assert.AreEqual(updatedProduct.Name, result.Name);
        }

        [Test]
        public async Task UpdateProductExceptionTest()
        {
            //Arrange
            Product updatedProduct = new Product()
            {
                Id = 11,
                Name = "KitKat",
                Price = 20,
                QuantityInHand = 5,
            };
            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => productServices.UpdateProduct(updatedProduct));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetAllProductSuccesTest()
        {
            //action
            var result = await productServices.GetAllProducts();

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetAllProductExceptionTest()
        {
            //Action
            productServices.DeleteProduct(1);
            var exception = Assert.ThrowsAsync<NoProductFoundException>(() => productServices.GetAllProducts());

            //Assert
            Assert.AreEqual("No Product Found", exception.Message);
        }
    }
}