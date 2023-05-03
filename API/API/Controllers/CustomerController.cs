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
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository costumerRepository)
        {
            _customerRepository = costumerRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetById(int id) 
        {
            var customer = await _customerRepository.GetAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer) 
        {
            try
            {
                await _customerRepository.CreateAsync(customer);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString);
                return BadRequest(ex.Message);
            }
            return Ok(customer);
            // return CreatedAtAction(nameof(GetById), new {id=customer.Id},customer);
        }

        [HttpPut("{id")]
        public async Task<IActionResult> Update([FromBody] Customer customer) 
        {
            try
            {
                await _customerRepository.UpdateAsync(customer);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return BadRequest();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer c = await _customerRepository.GetAsync(id);
            try
            {
                await _customerRepository.DeleteAsync(c);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return BadRequest();
            }

            return Ok(c);
        }
        /*[HttpPost]
        public async Task<IActionResult>
        {
            var customer = await _customerRepository.CreateAsync(id);
            return Ok(customer);
            /*using (var connection = new SqlConnection(_customerRepository))
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
        }*/
    }
}
