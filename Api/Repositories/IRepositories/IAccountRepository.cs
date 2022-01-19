using Api.Models;

namespace Api.Repositories.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> CheckLogin(string email, string password);
        

    }
}

