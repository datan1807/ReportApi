using System.Linq.Expressions;

namespace Api.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Update(T entity);
        Task DeleteById(T entity);
        Task Insert(T entity);
    }
}
