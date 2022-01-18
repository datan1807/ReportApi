using Api.Dtos;

namespace Api.Services.IService
{
    public interface IAccountService :IGenericService<AccountDto>
    {
        Task<bool> CheckLogin(string mail, string pass);
    }
}
