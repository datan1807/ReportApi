using Api.Dtos;
using Api.Dtos.ExtendedDto;

namespace Api.Services.IService
{
    public interface ISubmitService:IGenericService<SubmitDto>
    {
        Task<ExtendedSubmitDto> GetByProjectAndReport(int reportId, int projectId);
    }
}
