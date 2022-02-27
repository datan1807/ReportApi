using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<AccountDto> CheckLogin(string mail, string pass);
        Task<ResponseData<ExtendedAccountDto>> Search(AccountParameter param);
        Task<ExtendedAccountDto> GetByEmail(string email);
        Task<bool> UpdateStatus(string email);
    }
}
