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
        private readonly IRepository<int, Customer> _customerRepository;
        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                await _customerRepository.GetByKey(customer.Id);
            }
            catch (NoCustomerWithGiveIdException exp)
            {
                return await _customerRepository.Add(customer);
            }
            throw new CustomerAlreadyExistsException();

        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            Customer customerToDelete = await _customerRepository.GetByKey(customerId);
            return await _customerRepository.Delete(customerId);
        }

        public async Task<ICollection<Customer>> GetAllCustomer()
        {
            var customers = await _customerRepository.GetAll();
            if (customers.Any())
            {
                return customers;
            }
            throw new NoCustomerFoundException();

        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _customerRepository.GetByKey(customerId);
        }


        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = await _customerRepository.GetByKey(customer.Id);
            return await _customerRepository.Update(customer);
        }
    }
}
