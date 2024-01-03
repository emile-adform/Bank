using AutoMapper;
using Bank.WebApi.Exceptions;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;

namespace Bank.WebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AccountRepository _accountRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public UserService(UserRepository userRepository, IMapper mapper, AccountRepository accountRepository, TransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task Create(CreateUser user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            await _userRepository.CreateUser(entity);
        }
        public async Task<IEnumerable<UserEntity>> Get()
        {
            return await _userRepository.GetAll();
        }
        public async Task<UserEntity> Get(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }
        public async Task<IEnumerable<AccountEntity>> GetAccounts(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            var accounts = await _accountRepository.GetAccounts(userId);
            return accounts;
        }
        public async Task<IEnumerable<TransactionEntity>> GetTransactions(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            var transactions = await _transactionRepository.GetTransactions(userId);
            return transactions;
        }
        public async Task Update(int id, EditUser updateUser)
        {
            var user = await _userRepository.GetById(id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            user.Name = updateUser.Name;
            user.Address = updateUser.Address;

            await _userRepository.EditUser(user);
        }
        public async Task Delete(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.Delete(id);
        }
    }
}
