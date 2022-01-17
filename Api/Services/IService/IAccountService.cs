using Api.Dtos;
using Api.Models;

namespace Api.Services.IService
{
    public interface IAccountService
    {
        Task<Account> GetById(int id);
        Task Insert(Account account);
        Task Update(Account account);
        Task Delete(Account account);
        Task<IEnumerable<Account>> Get();
        Task<AccountDto> CheckLogin(String mail, String password);
    }
}
