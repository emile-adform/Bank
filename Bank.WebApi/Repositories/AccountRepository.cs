using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Dapper;
using System.Data;

namespace Bank.WebApi.Repositories
{
    public class AccountRepository
    {
        private readonly IDbConnection _connection;
        public AccountRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task Create(CreateAccount account)
        {
            string sql = $"INSERT INTO accounts (user_id, acc_type) VALUES (@UserId, CAST(@Type AS account_type))";
            var args = new
            {
                UserId = account.UserId,
                Type = account.Type.ToString()
            };
            await _connection.ExecuteAsync(sql, args);
        }
        public async Task<AccountEntity?> Get(int Id)
        {
            string sql = $"SELECT id, user_id AS UserId, balance, acc_type AS Type FROM accounts WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<AccountEntity?>(sql, new { Id });
        }
        public async Task<IEnumerable<AccountEntity>> Get()
        {
            string sql = $"SELECT id, user_id AS UserId, balance, acc_type AS Type FROM accounts";
            return await _connection.QueryAsync<AccountEntity>(sql);
        }
    }
}
