using Dapper;
using System.Data;

namespace Bank.WebApi.Repositories
{
    public class TransactionRepository
    {
        private readonly IDbConnection _connection;
        public TransactionRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task AddTransaction(int AccountId, double amount, string reason)
        {
            string sql = $"INSERT INTO transactions (account_id, amount, cause) VALUES (@AccountId, @amount, @reason)";
            await _connection.ExecuteAsync(sql, new { AccountId, amount, reason });
        }
    }
}
