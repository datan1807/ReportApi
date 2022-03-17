using Api.Data;
using Api.Dtos.ExtendedDto;
using Api.Global;
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

        public async Task<bool> CheckExist(ExtendedAccountGroupDto dto)
        {
            var entity = await _context.AccountGroups.Where(a =>
            a.Account.Id == dto.AccountId && a.Account.RoleId == Constants.Role.STUDENT
            && a.Group.Year == dto.Year && a.Group.Semester == dto.Semester).FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Group>> FindByAccount(string email)
        {
            var entities = await _context.AccountGroups.Where(c => c.Account.Email == email).Select(g => new Group {
                Id = g.Group.Id,
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
                ProjectName = e.Group.Project.ProjectName,
                Role = e.Role
            }).ToListAsync();
           return entities;
        }

        public async Task<IEnumerable<ExtendedAccount>> GetAccountByGroup(string groupCode)
        {
            var entities = await _context.AccountGroups.Where(a => a.Group.GroupCode == groupCode).Select(a => new ExtendedAccount
            {
                Email = a.Account.Email,
                AccountCode = a.Account.AccountCode,
                Fullname = a.Account.Fullname,
                RoleId = a.Account.RoleId,
                RoleName = a.Account.Role.Name,
                Id = a.Account.Id,
                RoleInGroup = a.Role
            }).ToListAsync();
            return entities;
        }
    }
}
