using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;

namespace Bank.WebApi.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly AccountRepository _accountRepository;
        public TransactionService(TransactionRepository transactionRepository, AccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public Task<IEnumerable<TransactionEntity>> Get()
        {
            return _transactionRepository.Get();
        }
    }
}
