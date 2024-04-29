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
        public async Task CreateCartSuccessTest()
        {
            //Action
            var result = await cartServices.CreateCart(2);

            //Assert
            Assert.AreEqual(result.CustomerId, 2);
        }

        [Test]
        public async Task CreateCartFailureTest()
        {
            //Action
            var result = await cartServices.CreateCart(2);

            //Assert
            Assert.NotNull(result);
        }


        [Test]
        public async Task CreateCartExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<CartAlreadyExistsForTheGivenCustomer>(async () => await cartServices.CreateCart(1));

            //Assert
            Assert.AreEqual("Cart for the customer already exists", exception.Message);
        }

        [Test]
        public async Task GetCartByCustomerIdSucessTest()
        {
            //Action
            var cartResult = await cartServices.GetCartByCustomerID(1);

            //assert
            Assert.AreEqual(cartResult.CustomerId, 1);
        }


        [Test]
        public async Task GetCartByCustomerIdExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<NoCartFoundForTheCustomerIdGivenException>(() => cartServices.GetCartByCustomerID(2));

            //Assert
            Assert.AreEqual("Cart for the customer not exists", exception.Message);
        }

        [Test]
        public async Task AddCartItemSuccessTest()
        {
            //Action
            var cartResult = await cartServices.AddCartItem(100, 1, 2);

            //assert
            Assert.IsNotNull(cartResult);
        }

        [Test]
        public async Task AddCartItemFailureTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<MaxQuantityExceededException>(() => cartServices.AddCartItem(100, 1, 10));

            //Assert
            Assert.AreEqual("Maximum Cart Quantity Reached", exception.Message);
        }

        [Test]
        public async Task AddCartItemCartNotFoundExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => cartServices.AddCartItem(120, 1, 10));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }

        [Test]
        public async Task AddCartItemProductNotFoundExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => cartServices.AddCartItem(100, 11, 10));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task RemoveCartItemSuccessTest()
        {
            //Action
            await cartServices.AddCartItem(100, 1, 2);
            var results = await cartServices.RemoveCartItem(100, 1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public async Task RemoveCartItemFailureTest()
        {
            //Action
            await cartServices.AddCartItem(100, 1, 2);
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => cartServices.RemoveCartItem(101, 1));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }


        [Test]
        public async Task RemoveCartItemExceptionTest()
        {
            //Action
            await cartServices.AddCartItem(100, 1, 2);
            var exception = Assert.ThrowsAsync<NoCartItemFoundExeption>(() => cartServices.RemoveCartItem(100, 2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }

        [Test]
        public async Task CalculateTotalAmountSuccessTest()
        {
            //Action
            await cartServices.AddCartItem(100, 1, 1);
            var cart = await cartServices.AddCartItem(100, 1, 1);

            var results = await cartServices.CalculateTotalAmountAfterDiscountAndShippingCharge(cart);

            //Assert
            Assert.Less(results, 201);
        }


        [Test]
        public async Task CalculateTotalAmountDiscountSuccessTest()
        {
            //Action
            await cartServices.AddCartItem(100, 1, 1);
            var cart = await cartServices.AddCartItem(100, 2, 2);

            var results = await cartServices.CalculateTotalAmountAfterDiscountAndShippingCharge(cart);

            //Assert
            Assert.Less(results, 2810);
        }

    }
}