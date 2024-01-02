using AutoMapper;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;
using Bank.WebApi.Repositories;

namespace Bank.WebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Create(CreateUser user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            await _userRepository.CreateUser(entity);
        }
    }
}
