using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetByCustomer([FromQuery] int customerId)
        {
            try
            {
                var accounts = await _accountRepository.GetAccountsByCustomerAsync(customerId);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account Account)
        {
            try
            {
                await _accountRepository.CreateAsync(Account);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Account account)
        {
            try
            {
                await _accountRepository.UpdateAsync(account);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _accountRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
