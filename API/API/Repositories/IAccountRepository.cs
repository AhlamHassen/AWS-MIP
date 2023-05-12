using API.Models;

namespace API.Repositories
{
    public interface IAccountRepository
    {
        Task<Account[]> GetAccountsByCustomerAsync(int customerId);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int accountId);
    }
}
