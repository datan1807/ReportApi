using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly QlreportContext _context;
        public RoleRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
