using System.Linq.Expressions;

namespace Shaghalni.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria = null, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip,
            int? take, Expression<Func<T, bool>> orderBy = null, string direction = "ASC");
        Task<T> AddAsync(T entity);
        void Update(T entity);
        T Delete(int id);
        Task<int> CountAsync();
    }
}
