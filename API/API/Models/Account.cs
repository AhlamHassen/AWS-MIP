namespace API.Models
{
    public record Account(int AccountId, int CustomerId, string AccountType, decimal Balance);
}