using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;

namespace Shopping.Test.DAL
{
    public class ProductRepositoryDALTest
    {
        IRepository<int, Product> repository;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
        }

        [Test]
        public void AddSuccessTest()
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
            var result = repository.Add(newProduct);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            Product newProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            //Action
            var result = repository.Add(newProduct);
            //Assert
            Assert.AreEqual(result.Id,1);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            //Action
            var result = repository.GetAll();

            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllFailureTest()
        {

            //Action
            var result = repository.GetAll();

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            //Action
            var result = repository.GetByKey(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void GetByKeyExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            //Action
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);

        }

        [Test]
        public void DeleteProductSucessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            //Action
            var results = repository.Delete(1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            //Action
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCustomerSucessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            Product updatedProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 11,
                QuantityInHand = 10,
            };

            //Action
            var results = repository.Update(updatedProduct);

            //Assert
            Assert.AreEqual(results.Price, updatedProduct.Price);

        }

        [Test]
        public void UpdateProductExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            repository.Add(product);

            Product updatedProduct = new Product()
            {
                Id = 2,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            //Action
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => repository.Update(updatedProduct));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);

        }

    }
}