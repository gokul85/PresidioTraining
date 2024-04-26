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
    public class CartRepositoryTest
    {
        IRepository<int, Cart> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Cart cart=new Cart() { 
                Id =1,
                CustomerId=10,
                CartItems=new List<CartItem>() { },
                Customer = new Customer() { },
            };

            //Action
            var result = repository.Add(cart);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Cart cart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };

            repository.Add(cart);
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };

            //Action
            var result = repository.Add(newCart);
            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

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
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            var results = repository.Delete(1);
            Assert.NotNull(results);
        }

        [Test]
        public void CartItemDeleteFailureTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            //Action
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }


        [Test]
        public void GetByKeySuccessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            //Action
            var result = repository.GetByKey(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void GetByKeyExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            //Action
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }

        [Test]
        public void DeleteCartSucessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            //Action
            var results = repository.Delete(1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public void DeleteCartExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            //Action
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }

        [Test]
        public void UpdateCartSucessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);

            Cart updatedCart = new Cart()
            {
                Id = 1,
                CustomerId = 15,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };


            //Action
            var results = repository.Update(updatedCart);

            //Assert
            Assert.AreEqual(results.CustomerId, updatedCart.CustomerId);

        }

        [Test]
        public void UpdateCartExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            repository.Add(newCart);


            Cart updatedCart = new Cart()
            {
                Id = 2,
                CustomerId = 15,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            //Action
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => repository.Update(updatedCart));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }

    }
}
