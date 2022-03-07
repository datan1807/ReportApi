using Api.Dtos;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IProjectService:IGenericService<ProjectDto>
    {
        Task<PagingData<ProjectDto>> Search(ProjectParameter param);
        Task Inactive(int id);
    }
}
