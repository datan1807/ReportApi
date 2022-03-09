using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;

namespace Api.Repositories.IRepositories
{
    public interface IGroupRepository:IGenericRepository<Group>
    {
        Task<PagedList<ExtendedGroup>> Search(GroupParameter param);
    }
}
