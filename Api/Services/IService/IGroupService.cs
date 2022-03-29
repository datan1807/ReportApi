using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IGroupService :IGenericService<GroupDto>
    {
        Task<IEnumerable<ExtendedGroupDto>> GetGroupByAccount(string accountId);
        Task<PagingData<ExtendedGroupDto>> Search(GroupParameter param);
        Task<bool> CheckCodeExist(string groupCode);
        Task<ExtendedGroupDto> GetByGroupId(int groupId);
        Task<bool> InsertGroup(ExtendedGroupInsertDto dto);
    }
}
