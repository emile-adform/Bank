using Bank.WebApi.Models.Entities;
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
        public async Task<IEnumerable<TransactionEntity>> Get()
        {
            string sql = $"SELECT id, account_id AS AccountId, amount, cause AS description, created_at FROM transactions";
            return await _connection.QueryAsync<TransactionEntity>(sql);
        }
        public async Task<IEnumerable<TransactionEntity?>> GetTransactions(int userId)
        {
            string sql = $"SELECT t.id, t.account_id AS AccountId, a.acc_type AS Type, t.amount, t.cause AS Description, t.created_at " +
                $"FROM transactions t " +
                $"JOIN accounts a ON t.account_id = a.id " +
                $"WHERE a.user_id = @userId " +
                $"ORDER BY t.id";
            return await _connection.QueryAsync<TransactionEntity>(sql, new { userId });
        }
    }
}
