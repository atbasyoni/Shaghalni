using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Jobs;
using Shaghalni.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext context) : base(context) { }
    }
}
