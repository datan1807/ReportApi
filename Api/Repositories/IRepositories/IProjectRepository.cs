using Api.Global;
using Api.Models;
using Api.Parameters;

namespace Api.Repositories.IRepositories
{
    public interface IProjectRepository :IGenericRepository<Project>
    {
        Task<PagedList<Project>> Search(ProjectParameter param);
    }
}
