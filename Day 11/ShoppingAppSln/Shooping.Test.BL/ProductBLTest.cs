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
        public void CreateProductSuccessTest()
        {
            Product newProduct = new Product()
            {
                Id = 2,
                Name = "MilkiBar",
                Price = 12,
                QuantityInHand = 20,
            };
            //Action
            var result = productServices.CreateProduct(newProduct);

            //Assert
            Assert.AreEqual(result.Id,newProduct.Id);
        }

        [Test]
        public void CreateProductExceptionTest()
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
            var exception = Assert.Throws<ProductAlreadyExistsException>(() => productServices.CreateProduct(newProduct));
            
            //Assert
            Assert.AreEqual("Product Already Exists", exception.Message);
        }

        [Test]
        public void DeleteProductSuccesTest()
        {
            //Action
            var result = productServices.DeleteProduct(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => productServices.DeleteProduct(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetProductsByIDSuccessTest()
        {
            //Action
            var result = productServices.GetProductById(1);
            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetProductsByIDExceptionTest()
        {
            //Action
            productServices.DeleteProduct(1);
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => productServices.GetProductById(1));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetProductsByNameSuccessTest()
        {
            //Action
            var result = productServices.GetProductByName("KitKat");
            //Assert
            Assert.AreEqual("KitKat",result.Name);
        }

        [Test]
        public void GetProductsByNameExceptionTest()
        {
            //Action
            productServices.DeleteProduct(1);
            var exception = Assert.Throws<NoProductFoundException>(() => productServices.GetProductByName("DiaryMilk"));
            //Assert
            Assert.AreEqual("No Product Found", exception.Message);
        }

        [Test]
        public void UpdateProductSuccessTest()
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
            var result = productServices.UpdateProduct(updatedProduct);
            //Assert
            Assert.AreEqual(updatedProduct.Name,result.Name);
        }

        [Test]
        public void UpdateProductExceptionTest()
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
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => productServices.UpdateProduct(updatedProduct));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllProductSuccesTest()
        {
            //action
            var result = productServices.GetAllProducts();

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllProductExceptionTest()
        {
            //Action
            productServices.DeleteProduct(1);
            var exception = Assert.Throws<NoProductFoundException>(() => productServices.GetAllProducts());
            
            //Assert
            Assert.AreEqual("No Product Found", exception.Message);
        }
    }
}