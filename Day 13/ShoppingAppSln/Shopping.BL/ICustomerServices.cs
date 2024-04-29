using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL
{
    public interface ICustomerServices
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int customerId);
        Task<ICollection<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int customerId);
    }
}
