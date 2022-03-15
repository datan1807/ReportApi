using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<AccountDto> CheckLogin(string mail, string pass);
        Task<PagingData<ExtendedAccountDto>> Search(AccountParameter param);
        Task<ExtendedAccountDto> GetByEmail(string email);
        Task<bool> UpdateStatus(int id);
        Task<IEnumerable<ExtendedAccountDto>> GetAccountByGroup(string groupCode);
        Task<IEnumerable<AccountDto>> GetByRole(int role);
        Task<IEnumerable<AccountDto>> GetByCode(string code, int role);
    }
}
