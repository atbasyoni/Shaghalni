using Microsoft.EntityFrameworkCore;
using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Jobs;
using Shaghalni.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Tuple<List<Job>, int>> FindAllAsync(Expression<Func<Job, bool>> criteria, int? skip, int? take, Expression<Func<Job, bool>> orderBy = null, string direction = "ASC", string[] includes = null)
        {
            IQueryable<Job> query = _context.Set<Job>();

            var jobsCount = query.Count();

            if (criteria is not null)
                query = query.Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy is not null)
            {
                if (direction == "ASC")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            if (includes is not null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            
            var totalPages = (int) Math.Ceiling(jobsCount / 8.0);
            var totalJobs = await query.ToListAsync();

            return new Tuple<List<Job>, int> (totalJobs, totalPages);
        }
    }
}
