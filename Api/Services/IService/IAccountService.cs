using Api.Dtos;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<bool> CheckLogin(string mail, string pass);
        Task<ResponseData<AccountDto>> GetByRole(AccountParameter param);
    }
}
