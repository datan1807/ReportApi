using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface ISubmitService:IGenericService<SubmitDto>
    {
        Task<ExtendedSubmitDto> GetByReportAndGroup(int reportId, int groupId);
        Task<PagingData<ExtendedSubmitDto>> Search(SubmitParameter param);
    }
}
