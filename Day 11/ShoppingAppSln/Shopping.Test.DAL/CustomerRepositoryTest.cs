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
    public class CustomerRepositoryTest
    {
        IRepository<int, Customer> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            //Action
            var result = repository.Add(customer);
            //Assert
            Assert.AreEqual(100, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            //Arrange 
            Customer newCustomer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            //Action
            var result = repository.Add(newCustomer);
            //Assert
            Assert.AreEqual(result.Id, 100);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

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
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            //Action
            var result = repository.GetByKey(100);

            //Assert
            Assert.AreEqual(result.Id, 100);
        }

        [Test]
        public void GetByKeyExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);

        }

        [Test]
        public void DeleteCustomerSucessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            //Action
            var results = repository.Delete(100);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCustomerSucessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            Customer updatedCustomer = new Customer()
            {
                Id = 100,
                Age = 22,
                Phone = "9977881857"
            };

            //Action
            var results=repository.Update(updatedCustomer);

            //Assert
            Assert.AreEqual(results.Age, updatedCustomer.Age);

        }

        [Test]
        public void UpdateCustomerExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            repository.Add(customer);

            Customer updatedCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Phone = "9977881857"
            };

            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Update(updatedCustomer));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);

        }

    }
}
