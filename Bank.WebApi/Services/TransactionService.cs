using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;

namespace Bank.WebApi.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Task<IEnumerable<TransactionEntity>> Get()
        {
            return _transactionRepository.Get();
        }
    }
}
