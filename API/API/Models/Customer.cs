namespace API.Models
{
    public record Customer (int CustomerId, string FirstName, string LastName, string Email, string Phone, string Address);
}