using Api.Models;

namespace Api.Repositories.IRepositories
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        Task<Account> CheckLogin(string mail, string password);
        Task<bool> CheckMailExisted(String mail);
    }
}
