using Shopping.BL;
using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.BL
{
    public class CartBLTest
    {
        IRepository<int, Cart> cartRepository;
        IRepository<int, Product> productRepository;
        ICartServices cartServices;
        IProductServices productServices;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            productRepository = new ProductRepository();


            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 20,
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "DiaryMilk",
                Price = 1400,
                QuantityInHand = 5,
            };


            Cart cart = new Cart()
            {
                Id = 100,
                CustomerId = 1,
                Customer = new Customer() { Id = 10, Age = 20, Phone = "9677381857" },
                CartItems = new List<CartItem>()
            };

            cartRepository.Add(cart);
            productRepository.Add(product);
            productRepository.Add(product2);


            cartServices = new CartBL(cartRepository, productRepository);
        }

        [Test]
        public void CreateCartSuccessTest()
        {
            //Action
            var result = cartServices.CreateCart(2);

            //Assert
            Assert.AreEqual(result.CustomerId, 2);
        }

        [Test]
        public void CreateCartFailureTest()
        {
            //Action
            var result = cartServices.CreateCart(2);

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            //Action
            var cartResult=cartServices.AddCartItem(100, 1, 2);

            //assert
            Assert.IsNotNull(cartResult);
        }

        [Test]
        public void AddCartItemFailureTest()
        {
            //Action
            var exception = Assert.Throws<MaxQuantityExceededException>(() => cartServices.AddCartItem(100, 1, 10));

            //Assert
            Assert.AreEqual("Maximum Cart Quantity Reached", exception.Message);
        }

        [Test]
        public void AddCartItemCartNotFoundExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => cartServices.AddCartItem(120, 1, 10));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }

        [Test]
        public void AddCartItemProductNotFoundExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGiveIdException>(() => cartServices.AddCartItem(100, 11, 10));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void RemoveCartItemSuccessTest()
        {
            //Action
            cartServices.AddCartItem(100, 1, 2);
            var results = cartServices.RemoveCartItem(100, 1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public void RemoveCartItemFailureTest()
        {
            //Action
            cartServices.AddCartItem(100, 1, 2);
            var exception = Assert.Throws<NoCartWithGivenIDException>(() => cartServices.RemoveCartItem(101, 1));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }


        [Test]
        public void RemoveCartItemExceptionTest()
        {
            //Action
            cartServices.AddCartItem(100, 1, 2);
            var exception = Assert.Throws<NoCartItemFoundExeption>(() => cartServices.RemoveCartItem(100, 2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }

        [Test]
        public void CalculateTotalAmountSuccessTest()
        {
            //Action
            cartServices.AddCartItem(100, 1, 1);
            var cart = cartServices.AddCartItem(100, 1, 1);

            var results = cartServices.CalculateTotalAmountAfterDiscountAndShippingCharge(cart);

            //Assert
            Assert.Less(results,201);
        }


        [Test]
        public void CalculateTotalAmountDiscountSuccessTest()
        {
            //Action
            cartServices.AddCartItem(100, 1, 1);
            var cart = cartServices.AddCartItem(100, 2, 2);

            var results = cartServices.CalculateTotalAmountAfterDiscountAndShippingCharge(cart);

            //Assert
            Assert.Less(results,2810);
        }

    }
}