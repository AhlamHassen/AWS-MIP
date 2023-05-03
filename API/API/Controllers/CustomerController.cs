using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using API.Repositories;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly string _connectionString;

        public CustomerController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MyDbConnection");
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Customer>("SELCET * FROM Customer");
            }
        }

        [HttpGet("{id")]
        public Customer GetById(int id) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<Customer>("SELECT * FROM Customer WHERE Id = @Id", new {Id = id});
            }
        }

        [HttpPost]
        public void Create(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Customer (Name, Email) VALUES (@Name, @Email)", customer);
            }
        }

        [HttpPut("{id")]
        public void Update(int id, Customer customer)
        {   
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Customer SET Name = @Name, Email = @Email WHERE Id = @Id", customer);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Customer WHERE Id = @Id", new { id = id});
            }
        }
    }
}
