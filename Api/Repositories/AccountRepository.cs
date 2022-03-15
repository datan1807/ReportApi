using Api.Data;
using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;
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
                RoleName = e.Role.Name,
                Id = e.Id,
                AccountCode = e.AccountCode,
                Status = e.Status

            }).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<ExtendedAccount> GetByEmail(string email)
        {
            var entity = await _context.Accounts.Where(c => c.Email == email).Select(c => new ExtendedAccount
            {
                Email=c.Email,
                Fullname=c.Fullname,
                Address = c.Address,
                Birthday = c.Birthday,
                Phone = c.Phone,
                RoleId=c.RoleId,
                RoleName=c.Role.Name,
                Status = c.Status,
                AccountCode = c.AccountCode,
                Id = c.Id
            }).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<PagedList<ExtendedAccount>> Search(AccountParameter param)
        {
            var entity = await _context.Accounts.Where(a => a.Email.Contains(param.Email) && a.Fullname.Contains(param.Fullname)).Select(e => new ExtendedAccount
            {
                Email = e.Email,
                Fullname = e.Fullname,
                Address = e.Address,
                Phone = e.Phone,
                Birthday = e.Birthday,
                RoleId = e.RoleId,
                RoleName = e.Role.Name,
                Status = e.Status,
                Id = e.Id
            }).ToListAsync();
            if(!String.IsNullOrEmpty(param.Status))
            {
                entity = entity.Where(e => e.Equals(param.Status)).ToList();
            }
            if(param.RoleId > 0)
            {
                entity = entity.Where(e => e.RoleId == param.RoleId).ToList();
            }
            return PagedList<ExtendedAccount>.ToPagedList(entity,param.PageNumber,param.PageSize);
        }
    }
}
