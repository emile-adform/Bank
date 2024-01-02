using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpPost("{id}/topup")]
        public async Task<IActionResult> TopUp(double amount)
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
