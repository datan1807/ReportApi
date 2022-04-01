using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IMarkService :IGenericService<MarkDto>
    {
        Task<PagingData<ExtendedMarkDto>> Search(MarkParameter param);
        Task<IEnumerable<ExtendedMarkDto>> GetByGroup(int groupId, bool isClose, int roleId);
        Task<MarkDto> GetByAccount(int accountId);

        Task SubmitMark(List<MarkDto> listMarks);
    }
}
