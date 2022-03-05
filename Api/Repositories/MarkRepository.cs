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

        public async Task<PagedList<ExtendedMark>> Search(MarkParameter param)
        {
            var entities = await _context.Marks.Where(m => m.Account.Email.Contains(param.Email)).Join(
                _context.AccountGroups,
                m => m.Account.Id,
                g => g.AccountId,
                (m,g) => new ExtendedMark { 
                AccountCode = m.Account.AccountCode,
                Email = m.Account.Email,
                Fullname = m.Account.Fullname,
                Category = m.Category.Name,
                ProjectId = g.Group.ProjectId,
                ProjectName =g.Group.Project.Name,
                Semeter = g.Group.Semester,
                Year = g.Group.Year,
                CategoryId = m.CategoryId
                }).OrderByDescending(o => o.Year)
                .ToListAsync();
            if (String.IsNullOrEmpty(param.AccountCode))
            {
                entities = entities.Where(m => m.AccountCode == param.AccountCode).ToList();
            }
            if(param.ProjectId > 0)
            {
                entities = entities.Where(m => m.ProjectId == param.ProjectId).ToList();
            }
            if(param.CategoryId > 0)
            {
                entities = entities.Where(m => m.CategoryId == param.CategoryId).ToList();
            }
            return PagedList<ExtendedMark>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}
