using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly QlreportContext _context;
        public AccountRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckLogin(string email, string password)
        {
            var entity =  await _context.Accounts.Where(a => a.Email == email && a.Password == password).FirstOrDefaultAsync();
            if(entity == null)
            {
                return false;
            }
            return true;
        }
    }
}
