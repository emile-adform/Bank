using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;

namespace Bank.WebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Create(CreateUser user)
        {
            var newUser = new UserEntity { Name = user.Name, Address = user.Address };
            await _userRepository.CreateUser(newUser);
        }
    }
}
