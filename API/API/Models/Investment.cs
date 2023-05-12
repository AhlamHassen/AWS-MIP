namespace API.Models
{
    public record Investment(int InvestmentId, int AccountId, string InvestmentType, decimal InvestmentAmount, DateTime InvestmentDate);
}