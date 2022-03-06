using Api.Data;
using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;
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
            var entity = await _context.Submits.Where(s => s.ReportId == reportId && s.Group.ProjectId == projectId).Select(c => new ExtendedSubmit
            {
                ReportId = c.ReportId,
                Id = c.Id,
                ProjectName = c.Group.Project.ProjectName,
                ReportName = c.Report.Title,
                ReportUrl = c.ReportUrl,
                SubmitTime = c.SubmitTime
            }).FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return entity;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<PagedList<ExtendedSubmit>> Search(SubmitParameter param)
        {
            var entities = await _context.Submits.Select(s => new ExtendedSubmit
            {
                Id = s.Id,
                GroupId = s.GroupId,
                Group = s.Group,
                ReportId = s.ReportId,
                ProjectId = s.Group.ProjectId,
                ProjectName= s.Group.Project.ProjectName,
                ReportName = s.Report.Title,
                ReportUrl= s.ReportUrl,
                SubmitTime= s.SubmitTime
            }).OrderByDescending(o => o.SubmitTime).ToListAsync();
            if(param.Year > 0)
            {
                entities = entities.Where(e => e.Group.Year >= param.Year).ToList();
            }
            if(!String.IsNullOrEmpty(param.ProjectName))
            {
                entities = entities.Where(e => e.Group.Project.ProjectName.Contains(param.ProjectName)).ToList();
            }
            if(param.ReportId > 0)
            {
                entities = entities.Where(e => e.ReportId == param.ReportId).ToList();
            }
            if (!String.IsNullOrEmpty(param.Semester))
            {
                entities = entities.Where(e => e.Group.Semester.Contains(param.Semester)).ToList();
            }

            return PagedList<ExtendedSubmit>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}
