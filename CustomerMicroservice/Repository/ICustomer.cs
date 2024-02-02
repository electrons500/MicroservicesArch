using CustomerMicroservice.Models.Data.MicroservicedbContext;

namespace CustomerMicroservice.Repository
{
    public interface ICustomer
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<bool> AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(int id,Customer customer);
        Task<bool> DeleteCustomerAsync(int id);

    }
}
