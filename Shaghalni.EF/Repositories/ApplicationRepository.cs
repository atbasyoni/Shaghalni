using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Applications;
using Shaghalni.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Repositories
{
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ApplicationDbContext context) : base(context) { }
    }
}
