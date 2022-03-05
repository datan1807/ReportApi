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

        public async Task<IEnumerable<Group>> FindByAccount(string email)
        {
            var entities = await _context.AccountGroups.Where(c => c.Account.Email == email).Select(g => new Group {
                Id = g.Id,
                Project = g.Group.Project,
                ProjectId = g.Group.ProjectId,
                Semester = g.Group.Semester,
                Year = g.Group.Year,
            }).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<ExtendedAccountGroup>> FindByGroupId(int id)
        {
            var entities =await _context.AccountGroups.Where(c => c.GroupId == id).Select(e => new ExtendedAccountGroup
            {
                GroupId = e.GroupId,
                Id = e.Id,
                AccountId = e.AccountId,
                Email= e.Account.Email,
                ProjectName = e.Group.Project.Name
            }).ToListAsync();
           return entities;
        }
    }
}
