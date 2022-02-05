using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class SubmitRepository : GenericRepository<Submit>, ISubmitRepository
    {
        private readonly QlreportContext _context;
        public SubmitRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
