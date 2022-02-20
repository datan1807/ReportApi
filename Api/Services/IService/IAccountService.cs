using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<AccountDto> CheckLogin(string mail, string pass);
        Task<ResponseData<ExtendedAccountDto>> GetByRole(AccountParameter param);
        Task<ResponseData<ExtendedAccountDto>> Search(AccountParameter param);
    }
}
