using Api.Data;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly QlreportContext _context;
        public AccountRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExtendedAccount> CheckLogin(string email, string password)
        {
            var entity =  await _context.Accounts.Where(a => a.Email == email && a.Password == password).Select(e => new ExtendedAccount
            {
                Email = e.Email,
                Password = e.Password,
                Fullname = e.Fullname,
                RoleId = e.RoleId,
                RoleName = e.Role.Name
                

            }).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

       
    }
}
