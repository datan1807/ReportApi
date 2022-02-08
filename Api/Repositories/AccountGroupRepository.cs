using Api.Data;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Repositories
{
    public class AccountGroupRepository : GenericRepository<AccountGroup>, IAccountGroupRepository
    {
        private readonly QlreportContext _context;
        public AccountGroupRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExtendedAccountGroup>> FindByGroupId(int id)
        {
            var entities =await _context.AccountGroups.Where(c => c.GroupId == id).Select(e => new ExtendedAccountGroup
            {
                Account = e.Account,
                GroupId = e.GroupId,
                Id = e.Id,
                AccountId = e.AccountId
            }).ToListAsync();
           return entities;
        }
    }
}
