using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly QlreportContext _context;
        public ProjectRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
