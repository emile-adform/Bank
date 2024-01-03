using AutoMapper;
using Bank.WebApi.Models.DTOs;
using Bank.WebApi.Models.Entities;

namespace Bank.WebApi.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUser, UserEntity>().ReverseMap();
            CreateMap<EditUser, UserEntity>().ReverseMap();
            CreateMap<ReturnUserDto, UserEntity>().ReverseMap();
            CreateMap<ReturnAccountDto, AccountEntity>().ReverseMap();
        }
    }
}
