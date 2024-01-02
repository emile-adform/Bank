using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AccountService _accountService;
        public UserController(UserService userService, AccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser user)
        {
            await _userService.Create(user);
            return Created();
        }
        [HttpPost("{id}/create-account")]
        public async Task<IActionResult> CreateAccount(int id, string accountType)
        {
            await _accountService.Create(id, accountType);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.Get());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.Get(id));
        }
        [HttpGet("{id}/accounts")]
        public async Task<IActionResult> GetAccounts(int id)
        {
            return Ok(await _userService.GetAccounts(id));
        }
        [HttpGet("{id}/transactions")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            return Ok(await _userService.GetTransactions(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EditUser user)
        {
            await _userService.Update(id, user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
