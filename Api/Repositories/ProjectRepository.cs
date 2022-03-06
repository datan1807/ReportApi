using Api.Data;
using Api.Global;
using Api.Models;
using Api.Parameters;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly QlreportContext _context;
        public ProjectRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Project>> Search(ProjectParameter param)
        {
            var test = await _context.Projects.Where(c => c.Status.Contains(param.Status)).ToListAsync();
            var entities = await _context.Projects.Where(p => p.ProjectName.Contains(param.ProjectName)).ToListAsync();
            if (!string.IsNullOrEmpty(param.Status) || param.Status.Trim() != "")
            {
                entities = entities.Where(p =>p.Status == param.Status).ToList();
            }
            return PagedList<Project>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}
