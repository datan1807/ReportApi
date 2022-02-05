using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly QlreportContext _context;
        public GroupRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
