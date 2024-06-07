using Shaghalni.Core.Models.Jobs;
using System.Linq.Expressions;

namespace Shaghalni.Core.Interfaces
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<Tuple<List<Job>, int>> FindAllAsync(Expression<Func<Job, bool>> criteria, int? skip, int? take, Expression<Func<Job, bool>> orderBy = null, string direction = "ASC", string[] includes = null);
    }
}
