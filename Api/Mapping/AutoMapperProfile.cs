using Api.Dtos;
using AutoMapper;
using Api.Models;

namespace Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
