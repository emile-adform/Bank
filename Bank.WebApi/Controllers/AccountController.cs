﻿using Bank.WebApi.Services;
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
            return Ok();
        }
        [HttpPost("{id}/topup")]
        public async Task<IActionResult> TopUp(double amount)
        {
            return Ok();
        }
        [HttpPost("{id}/transfer")]
        public async Task<IActionResult> Transfer(int transferToId, double amount)
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
