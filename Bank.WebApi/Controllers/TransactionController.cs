using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int userId)
        {
            return Ok();
        }
    }
}
