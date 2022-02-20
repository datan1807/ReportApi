using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;

namespace Api.Repositories.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<ExtendedAccount> CheckLogin(string email, string password);
        Task<PagedList<ExtendedAccount>> Search(AccountParameter param);
        Task<ExtendedAccount> GetByEmail(string email);
    }
}

