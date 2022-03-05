using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class MarkCategoryRepository : GenericRepository<MarkCategory> , IMarkCategoryRepository
    {
        private readonly QlreportContext _context;

        public MarkCategoryRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
