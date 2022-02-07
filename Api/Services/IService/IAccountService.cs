using Api.Dtos;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<AccountDto> CheckLogin(string mail, string pass);
        Task<ResponseData<AccountDto>> GetByRole(AccountParameter param);
    }
}
