using API.Models;
using Dapper;
using System.Data;

namespace API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _conn;

        public async Task CreateAsync(Customer customer)
        {
            const string sql = "INSERT INTO Customer (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address);";
            await _conn.ExecuteAsync(sql, customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            const string sql = "DELETE FROM Customer WHERE Id = @Id;";
            await _conn.ExecuteAsync(sql, customer);
        }

        public async Task<Customer[]> GetAllAsync()
        {
            const string sql = "SELECT * FROM Customer;";
            Customer[] customers = (await _conn.QueryAsync<Customer>(sql)).ToArray();

            return customers;
        }

        public async Task<Customer> GetAsync(int id)
        {
            const string sql = "SELECT * FROM Customer WHERE Id = @Id";
            Customer customer = await _conn.QuerySingleAsync<Customer>(sql, new { Id = id });
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            const string sql = @"UPDATE Customer
                                    SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address
                                    WHERE Id = @Id";

            await _conn.ExecuteAsync(sql, customer);
        }
    }
}
