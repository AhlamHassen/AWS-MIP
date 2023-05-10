using API.Models;
using Dapper;
using System.Data;

namespace API.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IDbConnection _conn;

        public InvestmentRepository(IDbConnection conn) { _conn = conn; }

        public async Task CreateAsync(Investment investment)
        {
            const string sql = "INSERT INTO Investment (AccountId, InvestmentType, InvestmentAmount, InvestmentDate) VALUES (@AccountId, @InvestmentType, @InvestmentAmount, @InvestmentDate);";
            await _conn.ExecuteAsync(sql, investment);
        }

        public async Task DeleteAsync(Investment investment)
        {
            const string sql = "DELETE FROM Investment where InvestmentId = @InvestmentId;";
            await _conn.ExecuteAsync(sql, investment);
        }

        public async Task<Investment[]> GetInvestmentsByAccountAsync(int accountId)
        {
            const string sql = "SELECT * FROM Investment WHERE AccountId = @AccountId";
            var investments = await _conn.QueryAsync<Investment>(sql, accountId);
            return investments.ToArray();
        }

        public async Task UpdateAsync(Investment account)
        {
            const string sql = "UPDATE Investment SET InvestmentType = @AccountType, Balance = @Balance WHERE AccountId = @AccountId;";
            await _conn.ExecuteAsync(sql, account);
        }
    }
}