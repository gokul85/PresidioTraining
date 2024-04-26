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
                Phone = "9677381857"
            };
            repository.Add(customer);
            customerServices = new CustomerBL(repository);
        }

        [Test]
        public void CreateCustomerSuccessTest()
        {
            Customer newCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Phone = "9699381857"
            };
            //Action
            var result = customerServices.CreateCustomer(newCustomer);

            //Assert
            Assert.AreEqual(result.Id, newCustomer.Id);
        }

        [Test]
        public void CreateCustomerExceptionTest()
        {
            //Arrange
            Customer newCustomer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };

            //Action
            var exception = Assert.Throws<CustomerAlreadyExistsException>(() => customerServices.CreateCustomer(newCustomer));

            //Assert
            Assert.AreEqual("Customer Already Exists", exception.Message);
        }


        [Test]
        public void DeleteCustomerSuccesTest()
        {
            //Action
            var result = customerServices.DeleteCustomer(100);
            //Assert
            Assert.AreEqual(100, result.Id);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerServices.DeleteCustomer(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetCustomerByIDSuccessTest()
        {
            //Action
            var result = customerServices.GetCustomerById(100);
            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetCustomerByIDExceptionTest()
        {
            //Action
            customerServices.DeleteCustomer(100);
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerServices.GetCustomerById(100));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCustomerSuccessTest()
        {
            //Arrange
            Customer updatedCustomer = new Customer()
            {
                Id = 100,
                Age = 22,
                Phone = "6977381857"
            };

            //Action
            var result = customerServices.UpdateCustomer(updatedCustomer);
            //Assert
            Assert.AreEqual(updatedCustomer.Age, result.Age);
        }

        [Test]
        public void UpdateCustomerExceptionTest()
        {
            //Arrange
            Customer updatedCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Phone = "6977381857"
            };

            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerServices.UpdateCustomer(updatedCustomer));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllTestSuccesTest()
        {
            //action
            var result = customerServices.GetAllCustomer();

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllTestExceptionTest()
        {
            //Action
            customerServices.DeleteCustomer(100);

            var exception = Assert.Throws<NoCustomerFoundException>(() => customerServices.GetAllCustomer());
            //Assert
            Assert.AreEqual("No Customer Found", exception.Message);
        }
    }
}
