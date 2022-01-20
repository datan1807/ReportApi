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

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> order = null,
            string includeProperties = "");
    }
}
