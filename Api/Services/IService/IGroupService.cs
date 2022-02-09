using Api.Dtos;
using Api.Dtos.ExtendedDto;

namespace Api.Services.IService
{
    public interface IGroupService :IGenericService<GroupDto>
    {
        Task<IEnumerable<ExtendedGroupDto>> GetGroupByAccount(string accountId);
    }
}
