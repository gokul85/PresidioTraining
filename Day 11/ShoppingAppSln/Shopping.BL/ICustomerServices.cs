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
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int customerId);
        ICollection<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerId);
    }
}
