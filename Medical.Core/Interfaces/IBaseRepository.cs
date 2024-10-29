

namespace Medical.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
