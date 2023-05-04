using API.Models;

namespace API.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountsByCustomerAsync(int customerId);
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int accountId);
    }
}
