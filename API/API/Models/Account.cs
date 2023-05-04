namespace API.Models
{
    public class Account
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public string AccountType { get; init; }
        public decimal Balance { get; init; }
    }
}
