using Api.Dtos;
using Api.Dtos.ExtendedDto;

namespace Api.Services.IService
{
    public interface IAccountGroupService :IGenericService<AccountGroupDto>
    {
        Task<IEnumerable<ExtendedAccountGroupDto>> FindByGroupId(int id);
        
    }
}
