using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ReportRepository : GenericRepository<Report>
    {
        private readonly QlreportContext _context;
        public ReportRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
