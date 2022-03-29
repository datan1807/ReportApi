using Api.Dtos;
using AutoMapper;
using Api.Models;
using Api.Dtos.ExtendedDto;
using Api.Models.ExtendedModels;

namespace Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Submit, SubmitDto>().ReverseMap();
            CreateMap<TeacherEvaluation, TeacherEvaluationDto>().ReverseMap();
            CreateMap<AccountGroup, AccountGroupDto>().ReverseMap();
            CreateMap<Mark, MarkDto>().ReverseMap();
            CreateMap<ExtendedGroup, ExtendedGroupDto>().ReverseMap();
            CreateMap<ExtendedAccount, ExtendedAccountDto>().ReverseMap();
        }
    }
}
