using Bank.WebApi.Models.Entities;
using Dapper;
using System.Data;

namespace Bank.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task CreateUser(UserEntity user)
        {
            string sql = $"INSERT INTO users (name, address) VALUES (@Name, @Address)";
            var args = new
            {
                Name = user.Name,
                Address = user.Address
            };
            await _connection.ExecuteAsync(sql, args);
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            string sql = $"SELECT * FROM users";
            return await _connection.QueryAsync<UserEntity>(sql);
        }
        public async Task<UserEntity?> GetById(int Id)
        {
            string sql = $"SELECT * FROM users WHERE id = @Id";
            var args = new
            {
                Id = Id
            };
            return await _connection.QueryFirstOrDefaultAsync<UserEntity?>(sql, args);
        }
        public async Task<IEnumerable<AccountEntity?>> GetAccounts(int userId)
        {
            string sql = $"SELECT * FROM accounts WHERE user_id = @userId";
            return await _connection.QueryAsync<AccountEntity>(sql, new {userId});
        }
        public async Task<IEnumerable<TransactionEntity?>> GetTransactions(int userId)
        {
            string sql = $"SELECT t.id, t.account_id, a.acc_type, t.amount, t.cause, t.created_at " +
                $"FROM transactions t " +
                $"JOIN accounts a ON t.account_id = a.id " +
                $"WHERE a.user_id = @userId " +
                $"ORDER BY t.id";
            return await _connection.QueryAsync<TransactionEntity>(sql, new { userId });
        }
        public async Task EditUser(UserEntity user)
        {
            string sql = $"UPDATE users SET name = @Name, address = @Address WHERE id = @Id";
            var args = new
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address
            };
            await _connection.ExecuteAsync(sql, args);
        }
        public async Task Delete(int Id)
        {
            string sql = $"DELETE FROM users WHERE id = @Id";

            await _connection.ExecuteAsync(sql, new {Id});
        }
    }
}
