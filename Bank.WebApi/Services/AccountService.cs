using AutoMapper;
using Bank.WebApi.Exceptions;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;
using System.Transactions;
using static Bank.WebApi.Models.DTOs.CreateAccount;
using static Bank.WebApi.Models.Entities.AccountEntity;

namespace Bank.WebApi.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly UserRepository _userRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public AccountService(AccountRepository accountRepository, UserRepository userRepository, TransactionRepository transactionRepository, 
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;

        }
        public async Task Create(int userId, string accountType)
        {
            var user = await _userRepository.GetById(userId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            var accounts = await _accountRepository.GetAccounts(userId);
            if (accounts.Count() > 1)
            {
                throw new MaxNumberOfAccountsReachedException();
            }
            AccountType type = Enum.Parse<AccountType>(accountType, true);
            var entity = new CreateAccount
            {
                UserId = userId,
                Type = type,
            };
            await _accountRepository.Create(entity);
        }
        public async Task<ReturnAccountDto?> Get(int id)
        {
            var account = await _accountRepository.Get(id);
            if (account is null)
            {
                throw new AccountNotFoundException();
            }
            return _mapper.Map<ReturnAccountDto>(account);
        }
        public async Task<IEnumerable<ReturnAccountDto>> Get()
        {
            var accounts = await _accountRepository.Get();
            var accountsDtos = new List<ReturnAccountDto>();
            foreach (var account in accounts)
            {
                accountsDtos.Add(_mapper.Map<ReturnAccountDto>(account));
            }
            return accountsDtos;
        }
        public async Task<double> TopUp(int id, double amount)
        {
            if(amount < 0)
            {
                throw new IllegalAmountException();
            }
            var account = await _accountRepository.Get(id);
            if (account is null)
            {
                throw new AccountNotFoundException();
            }

            string reason = "Top Up";
            double currentBalance = 0;

            using (var transactionScopeBalance = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    currentBalance = await _accountRepository.UpdateBalance(id, amount);
                    await _transactionRepository.AddTransaction(id, amount, reason);

                    transactionScopeBalance.Complete();
                    return currentBalance;
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
        }
        public async Task Transfer(int AccountFromId, int TransferToId, double Amount, string reason)
        {
            if (Amount < 0)
            {
                throw new IllegalAmountException();
            }
            var accountFrom = await _accountRepository.Get(AccountFromId);
            var accountTo = await _accountRepository.Get(TransferToId);

            if (accountFrom is null || accountTo is null)
            {
                throw new AccountNotFoundException();
            }
            if(AccountFromId == TransferToId)
            {
                throw new IllegalTransactionException();
            }
            if(accountFrom.Balance < Amount + 1)
            {
                throw new InsufficientFundsException();
            }
            var transferFee = 1.0;
            var transferFromAmount = (Amount + transferFee) * -1;

            using (var transactionScopeTransfer = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _transactionRepository.AddTransaction(AccountFromId, transferFromAmount, reason);
                    await _accountRepository.UpdateBalance(AccountFromId, transferFromAmount);
                    await _transactionRepository.AddTransaction(TransferToId, Amount, reason);
                    await _accountRepository.UpdateBalance(TransferToId, Amount);

                    transactionScopeTransfer.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
        }
        public async Task Delete(int id)
        {
            var account = await _accountRepository.Get(id);
            if(account is null || account.IsDeleted == true)
            {
                throw new AccountNotFoundException();
            }
            if(account.Balance > 0)
            {
                throw new ClosingNotEmptyAccountException();
            }
            await _accountRepository.Delete(id);
        }
    }
}
