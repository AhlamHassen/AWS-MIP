using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentRepository _investmentRepository;

        private InvestmentController(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvestmentsByAccount([FromQuery] int accountId)
        {
            try
            {
                var investments = await _investmentRepository.GetInvestmentsByAccountAsync(accountId);
                return Ok(investments);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Investment investment)
        {
            try
            {
                await _investmentRepository.CreateAsync(investment);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Investment investment)
        {
            try
            {
                await _investmentRepository.UpdateAsync(investment);
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
                await _investmentRepository.DeleteAsync(id);
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