using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface ISubmitService:IGenericService<SubmitDto>
    {
        Task<ExtendedSubmitDto> GetByProjectAndReport(int reportId, int projectId);
        Task<PagingData<ExtendedSubmitDto>> Search(SubmitParameter param);
    }
}
