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

        public async Task<Account> CheckLogin(string mail, string password)
        {
            var entity = await _context.Accounts.Where(a => a.Email == mail && a.Password == password).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
        }

        public async Task<bool> CheckMailExisted(string mail)
        {
            var entity = await _context.Accounts.Where(a => a.Email == mail).FirstOrDefaultAsync();
            if(entity != null)
            {
                return true;
            }
            return false;
        }
    }
}
