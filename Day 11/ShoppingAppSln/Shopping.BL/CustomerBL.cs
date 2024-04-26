using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL
{
    public class CustomerBL : ICustomerServices
    {
        private readonly IRepository<int,Customer> _customerRepository;
        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer CreateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.GetByKey(customer.Id);
            }
            catch (NoCustomerWithGiveIdException exp)
            {
                return _customerRepository.Add(customer);
            }
            throw new CustomerAlreadyExistsException();
            
        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer customerToDelete = _customerRepository.GetByKey(customerId);
            return _customerRepository.Delete(customerId);
        }

        public ICollection<Customer> GetAllCustomer()
        {
            var customers= _customerRepository.GetAll();
            if(customers.Any())
            {
                return customers;
            }
            throw new NoCustomerFoundException();
            
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetByKey(customerId);
        }


        public Customer UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = _customerRepository.GetByKey(customer.Id);
            return _customerRepository.Update(customer);
        }
    }
}
