using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.DAL
{
    public class CartItemRepositoryTest
    {
        IRepository<int, CartItem> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };

            //Action
            var result = repository.Add(cartItem);
            //Assert
            Assert.AreEqual(1, result.CartId);
        }

        [Test]
        public void AddFailureTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };

            //Action
            var result = repository.Add(newCartItem);
            //Assert
            Assert.AreEqual(result.CartId, 1);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

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
        public void CartItemDeleteSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            var results = repository.Delete(10);
            Assert.NotNull(results);
        }

        [Test]
        public void CartItemDeleteFailureTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Action
            var exception = Assert.Throws<NoCartItemFoundExeption>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);
        }


        [Test]
        public void GetByKeySuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Action
            var result = repository.GetByKey(10);

            //Assert
            Assert.AreEqual(result.CartId, 1);
        }

        [Test]
        public void GetByKeyExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Action
            var exception = Assert.Throws<NoCartItemFoundExeption>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }

        [Test]
        public void DeleteCartSucessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Action
            var results = repository.Delete(10);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public void DeleteCartExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Action
            var exception = Assert.Throws<NoCartItemFoundExeption>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);
        }

        [Test]
        public void UpdateCartSucessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);

            //Arrange 
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 299,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };


            //Action
            var results = repository.Update(newCartItem);

            //Assert
            Assert.AreEqual(results.Price, newCartItem.Price);

        }

        [Test]
        public void UpdateCartExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            repository.Add(cartItem);


            //Arrange 
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 1200,
                ProductId = 19,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 12,
                Quantity = 3
            };
            //Action
            var exception = Assert.Throws<NoCartItemFoundExeption>(() => repository.Update(newCartItem));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }
    }
}
