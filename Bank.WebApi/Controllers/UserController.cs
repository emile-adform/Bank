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
        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUser user)
        {
            await _userService.Create(user);
            return Created();
        }
        /// <summary>
        /// Creates new account for user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        [HttpPost("{id}/create-account")]
        public async Task<IActionResult> CreateAccount(int id, string accountType)
        {
            await _accountService.Create(id, accountType);
            return Created();
        }
        /// <summary>
        /// Gets list of all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.Get());
        }
        /// <summary>
        /// Gets user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.Get(id));
        }
        /// <summary>
        /// Gets accounts by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/accounts")]
        public async Task<IActionResult> GetAccounts(int id)
        {
            return Ok(await _userService.GetAccounts(id));
        }
        /// <summary>
        /// Gets users transactions by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/transactions")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            return Ok(await _userService.GetTransactions(id));
        }
        /// <summary>
        /// Updates users name and address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EditUser user)
        {
            await _userService.Update(id, user);
            return NoContent();
        }
        /// <summary>
        /// Deletes user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
