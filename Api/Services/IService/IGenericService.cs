namespace Api.Services.IService
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T>GetById(object id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
