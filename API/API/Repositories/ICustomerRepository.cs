using API.Models;

namespace API.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(int id);
        Task<Customer[]> GetAllAsync();

        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}