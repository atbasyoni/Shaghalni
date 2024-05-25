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
    public class JobDetailsRepository : BaseRepository<JobDetails>, IJobDetailsRepository
    {
        public JobDetailsRepository(ApplicationDbContext context) : base(context) { }
    }
}
