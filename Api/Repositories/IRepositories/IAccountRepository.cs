using Api.Models;
using Api.Models.ExtendedModels;

namespace Api.Repositories.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<ExtendedAccount> CheckLogin(string email, string password);
        

    }
}

