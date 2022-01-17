using System.Linq.Expressions;

namespace Api.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetById(object id);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
