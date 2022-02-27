using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;

namespace Api.Repositories.IRepositories
{
    public interface ISubmitRepository : IGenericRepository<Submit>
    {
        Task<ExtendedSubmit> GetByReportAndProject(int reportId, int projectId);
        Task<PagedList<ExtendedSubmit>> Search(SubmitParameter param);
    }
}
