using Shopping.Model;
using Shopping.Model.Exceptions;

namespace Shopping.DAL
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Id == key)
            //        return items[i];
            //}
            //throw new NoCustomerWithGiveIdException();

            Customer customer = items.FirstOrDefault(c => c.Id == key);
            if (customer != null)
            {
                return customer;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}
