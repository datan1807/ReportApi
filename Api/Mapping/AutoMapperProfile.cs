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
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CouncilEvaluation, CouncilEvaluationDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Submit, SubmitDto>().ReverseMap();
            CreateMap<TeacherEvaluation, TeacherEvaluationDto>().ReverseMap();
        }
    }
}
