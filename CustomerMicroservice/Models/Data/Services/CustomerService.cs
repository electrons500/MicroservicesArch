using CustomerMicroservice.Models.Data.MicroservicedbContext;
using CustomerMicroservice.Repository;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Models.Data.Services
{
    public class CustomerService : ICustomer
    {
        private readonly MicroservicedbContext.MicroservicedbContext _Context;
        public CustomerService(MicroservicedbContext.MicroservicedbContext context)
        {
            _Context = context;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
           await _Context.Customers.AddAsync(customer);
           await _Context.SaveChangesAsync();
           return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            Customer customer = await _Context.Customers.Where(x => x.Customerid == id).FirstOrDefaultAsync();
            _Context.Customers.Remove(customer);
            await _Context.SaveChangesAsync();

            return true;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _Context.Customers.Where(x => x.Customerid == id).FirstOrDefaultAsync();

        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _Context.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomerAsync(int id,Customer customer)
        {
            Customer getCustomer = await _Context.Customers.Where(x => x.Customerid == id).FirstOrDefaultAsync();
            getCustomer.Customerid = customer.Customerid;
            getCustomer.Customername = customer.Customername;
            getCustomer.Customercontact = customer.Customercontact;
            getCustomer.Customerlocation = customer.Customerlocation;
            _Context.Customers.Update(getCustomer);
            await _Context.SaveChangesAsync();

            return true;

        }
    }
}
