using Api.Data;
using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly QlreportContext _context;
        public GroupRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckExist(string groupCode)
        {
            var entity = await _context.Groups.Where(g => g.GroupCode == groupCode).FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public async Task<PagedList<ExtendedGroup>> Search(GroupParameter param)
        {
            var entities = await _context.Groups.Select(g => new ExtendedGroup
            {
                Id = g.Id,
                GroupCode = g.GroupCode,
                ProjectId = g.ProjectId,
                ProjectName = g.Project.ProjectName,
                Semester = g.Semester,
                Year = g.Year,
                Submits = g.Submits
            }).OrderByDescending(g => g.Year).ToListAsync();
               
            if(param.Year > 0)
            {
                entities = entities.Where(x=> x.Year == param.Year).ToList();
            }
            if (!String.IsNullOrEmpty(param.Semester))
            {
                entities = entities.Where(x => x.Semester == param.Semester).ToList();
            }
            if (!String.IsNullOrEmpty(param.GroupCode))
            {
                entities = entities.Where(x => x.GroupCode == param.GroupCode).ToList();
            }
            return PagedList<ExtendedGroup>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}
