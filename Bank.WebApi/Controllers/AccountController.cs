using Bank.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _accountService.Get(id));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _accountService.Get());
        }
        [HttpPost("{id}/topup")]
        public async Task<IActionResult> TopUp(int id, double amount)
        {
            return Ok(await _accountService.TopUp(id, amount));
        }
        [HttpPost("{id}/transfer")]
        public async Task<IActionResult> Transfer(int id, int transferToId, double amount, string reason)
        {
            await _accountService.Transfer(id, transferToId, amount, reason);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.Delete(id);
            return NoContent();
        }
    }
}
