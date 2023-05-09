using API.Models;
using Dapper;
using System.Data;

namespace API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _conn;

        public AccountRepository(IDbConnection conn) { _conn = conn; }

        public async Task CreateAsync(Account account)
        {
            const string sql = "INSERT INTO Account (CustomerId, AccountType, Balance) VALUES (@CustomerId, @AccountType, @Balance);";
            await _conn.ExecuteAsync(sql, account);
        }

        public async Task DeleteAsync(int accountId)
        {
            const string sql = "DELETE FROM Account where AccountId = @AccountId;";
            await _conn.ExecuteAsync(sql, accountId);
        }

        public async Task<Account[]> GetAccountsByCustomerAsync(int customerId)
        {
            const string sql = "SELECT * FROM Account WHERE CustomerId = @CustomerId";
            var accounts = await _conn.QueryAsync<Account>(sql, customerId);
            return accounts.ToArray();
        }

        public async Task UpdateAsync(Account account)
        {
            const string sql = "UPDATE Account SET AccountType = @AccountType, Balance = @Balance WHERE AccountId = @AccountId;";
            await _conn.ExecuteAsync(sql, account);
        }
    }
}