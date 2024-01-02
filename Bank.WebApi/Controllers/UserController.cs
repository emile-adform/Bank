using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
        [HttpGet("{id}/accounts")]
        public async Task<IActionResult> GetAccounts(int id)
        {
            return Ok();
        }
        [HttpGet("{id}/transactions")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
