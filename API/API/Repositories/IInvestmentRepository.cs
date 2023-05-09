using API.Models;

namespace API.Repositories
{
    public interface IInvestmentRepository
    {
        Task<Investment[]> GetInvestmentsByAccountAsync(int accountId);
        Task CreateAsync(Investment investment);
        Task UpdateAsync(Investment investment);
        Task DeleteAsync(Investment investment);
    }
}