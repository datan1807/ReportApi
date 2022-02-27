using Api.Data;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class SubmitRepository : GenericRepository<Submit>, ISubmitRepository
    {
        private readonly QlreportContext _context;
        public SubmitRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExtendedSubmit> GetByReportAndProject(int reportId, int projectId)
        {
            var entity = await _context.Submits.Where(s => s.ReportId == reportId && s.ProjectId == projectId).Select(c => new ExtendedSubmit
            {
                ReportId = c.ReportId,
                ProjectId = c.ProjectId,
                Id = c.Id,
                ProjectName = c.Project.Name,
                ReportName = c.Report.Title,
                ReportUrl = c.ReportUrl,
                SubmitTime = c.SubmitTime
            }).FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return entity;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
