using Bank.WebApi.Exceptions;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;
using static Bank.WebApi.Models.Entities.AccountEntity;

namespace Bank.WebApi.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly UserRepository _userRepository;
        public AccountService(AccountRepository accountRepository, UserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;

        }
        public async Task Create(int userId, string accountType)
        {
            var user = await _userRepository.GetById(userId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            AccountType type = Enum.Parse<AccountType>(accountType, true);
            var entity = new AccountEntity
            {
                UserId = userId,
                Type = type,
            };
            await _accountRepository.Create(entity);
        }
    }
}
