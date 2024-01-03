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
            string sql = @$"INSERT INTO users (name, address) 
                        VALUES (@Name, @Address)";
            var args = new
            {
                Name = user.Name,
                Address = user.Address
            };
            await _connection.ExecuteAsync(sql, args);
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            string sql = @$"SELECT id, name, address, is_deleted AS IsDeleted 
                        FROM users 
                        WHERE is_deleted = false";
            return await _connection.QueryAsync<UserEntity>(sql);
        }
        public async Task<UserEntity?> GetById(int Id)
        {
            string sql = @$"SELECT id, name, address, is_deleted AS IsDeleted 
                        FROM users 
                        WHERE id = @Id AND is_deleted = false";

            var args = new
            {
                Id = Id
            };
            return await _connection.QueryFirstOrDefaultAsync<UserEntity?>(sql, args);
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
            string sql = $"UPDATE users SET is_deleted = true WHERE id = @Id";

            await _connection.ExecuteAsync(sql, new {Id});
        }
    }
}
