using Bank.WebApi.Exceptions;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;
using static Bank.WebApi.Models.DTOs.CreateAccount;
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
            var entity = new CreateAccount
            {
                UserId = userId,
                Type = type,
            };
            await _accountRepository.Create(entity);
        }
        public async Task<AccountEntity?> Get(int id)
        {
            var account = await _accountRepository.Get(id);
            if (account is null)
            {
                throw new AccountNotFoundException();
            }
            return account;
        }
        public async Task<IEnumerable<AccountEntity>> Get()
        {
            return await _accountRepository.Get();
        }
    }
}
