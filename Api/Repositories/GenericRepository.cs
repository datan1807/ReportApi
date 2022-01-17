using Api.Data;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal QlreportContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(QlreportContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Delete(T entity)
        {
             _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

       

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
