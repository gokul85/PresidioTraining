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
    public class CustomerBLTest
    {
        IRepository<int, Customer> repository;
        ICustomerServices customerServices;
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Name = "Huzair",
                Phone = "9677381857"
            };
            repository.Add(customer);
            customerServices = new CustomerBL(repository);
        }

        [Test]
        public async Task CreateCustomerSuccessTest()
        {
            Customer newCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Name = "Ahmed",
                Phone = "9699381857"
            };
            //Action
            var result = await customerServices.CreateCustomer(newCustomer);

            //Assert
            Assert.AreEqual(result.Id, newCustomer.Id);
        }

        [Test]
        public async Task CreateCustomerExceptionTest()
        {
            //Arrange
            Customer newCustomer = new Customer()
            {
                Id = 100,
                Age = 20,
                Name = "Huzair",
                Phone = "9677381857"
            };

            //Action
            var exception = Assert.ThrowsAsync<CustomerAlreadyExistsException>(() => customerServices.CreateCustomer(newCustomer));

            //Assert
            Assert.AreEqual("Customer Already Exists", exception.Message);
        }


        [Test]
        public async Task DeleteCustomerSuccesTest()
        {
            //Action
            var result = await customerServices.DeleteCustomer(100);
            //Assert
            Assert.AreEqual(100, result.Id);
        }

        [Test]
        public async Task DeleteCustomerExceptionTest()
        {
            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => customerServices.DeleteCustomer(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetCustomerByIDSuccessTest()
        {
            //Action
            var result = await customerServices.GetCustomerById(100);
            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetCustomerByIDExceptionTest()
        {
            //Action
            await customerServices.DeleteCustomer(100);
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => customerServices.GetCustomerById(100));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateCustomerSuccessTest()
        {
            //Arrange
            Customer updatedCustomer = new Customer()
            {
                Id = 100,
                Age = 22,
                Name = "Huzair",
                Phone = "6977381857"
            };

            //Action
            var result = await customerServices.UpdateCustomer(updatedCustomer);
            //Assert
            Assert.AreEqual(updatedCustomer.Age, result.Age);
        }

        [Test]
        public async Task UpdateCustomerExceptionTest()
        {
            //Arrange
            Customer updatedCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Name = "Ahmed",
                Phone = "6977381857"
            };

            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => customerServices.UpdateCustomer(updatedCustomer));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetAllTestSuccesTest()
        {
            //action
            var result = await customerServices.GetAllCustomer();

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetAllTestExceptionTest()
        {
            //Action
            await customerServices.DeleteCustomer(100);

            var exception = Assert.ThrowsAsync<NoCustomerFoundException>(() => customerServices.GetAllCustomer());
            //Assert
            Assert.AreEqual("No Customer Found", exception.Message);
        }
    }
}
