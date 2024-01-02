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
    }
}
