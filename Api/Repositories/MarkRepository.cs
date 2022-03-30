using Api.Data;
using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MarkRepository : GenericRepository<Mark>, IMarkRepository
    {
        private readonly QlreportContext _context;

        public MarkRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExtendedMark>> GetByGroup(int groupId, bool isClose)
        {
            var entities = await _context.AccountGroups.Where(a => a.GroupId == groupId).Join(
                _context.Marks,
                a => a.AccountId,
                m => m.AccountId,
                (a, m) => new ExtendedMark
                {
                    Id = m.Id,
                    AccountCode = a.Account.AccountCode,
                    Email = a.Account.Email,
                    Fullname = a.Account.Fullname,
                    Report1 = m.Report1,
                    Report2 = m.Report2,
                    Report3 = m.Report3,
                    Report4 = m.Report4,
                    Report5 = m.Report5,
                    Report6 = m.Report6,
                    Report7 = m.Report7,
                    Final = m.Final,
                    Status = m.Status,
                    AccountId = m.AccountId,
                    ProjectId = a.Group.ProjectId,
                    ProjectName = a.Group.Project.ProjectName,
                    Semester = a.Group.Semester,
                    Year = a.Group.Year,
                    IsClose = m.IsClose
                }).ToListAsync();
            entities = entities.Where(a => a.IsClose == isClose).ToList();
            return entities;
            //var entities = await _context.Marks.Where(m => m.Account.RoleId == role).Join(
            //    _context.AccountGroups,
            //    m => m.AccountId,
            //    g => g.AccountId,
            //    (m,g) => new ExtendedMark
            //    {
            //        AccountCode = m.Account.AccountCode,
            //        Fullname = m.Account.Fullname,
            //        Email = m.Account.Email,

            //    }).ToListAsync();
            //return null;
        }

        public async Task<PagedList<ExtendedMark>> Search(MarkParameter param)
        {
            var entities = await _context.Marks.Where(m => m.Account.Email.Contains(param.Email)).Join(
                _context.AccountGroups,
                m => m.Account.Id,
                g => g.AccountId,
                (m, g) => new ExtendedMark
                {
                    Id = m.Id,
                    AccountCode = m.Account.AccountCode,
                    Email = m.Account.Email,
                    Fullname = m.Account.Fullname,
                    ProjectId = g.Group.ProjectId,
                    ProjectName = g.Group.Project.ProjectName,
                    Semester = g.Group.Semester,
                    Year = g.Group.Year,
                    AccountId = m.AccountId,
                    Report1 = m.Report1,
                    Report2 = m.Report2,
                    Report3 = m.Report3,
                    Report4 = m.Report4,
                    Report5 = m.Report5,
                    Report6 = m.Report6,
                    Final = m.Final,
                    Status = m.Status,
                    Report7 = m.Report7,
                    IsClose = m.IsClose
                }).OrderByDescending(o => o.Year)
                .ToListAsync();
            if (!String.IsNullOrEmpty(param.AccountCode))
            {
                entities = entities.Where(m => m.AccountCode == param.AccountCode).ToList();
            }
            if (param.ProjectId > 0)
            {
                entities = entities.Where(m => m.ProjectId == param.ProjectId).ToList();
            }
            return PagedList<ExtendedMark>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}
