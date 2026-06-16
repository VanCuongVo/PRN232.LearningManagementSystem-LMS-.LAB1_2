using System.Linq.Expressions;

namespace PRN232.LMS.Repositories.IRepositories
{
    public interface IGenericRepositories<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(object id);
        IQueryable<T> GetQueryable(); // trong quá trình build có search



    }
}
