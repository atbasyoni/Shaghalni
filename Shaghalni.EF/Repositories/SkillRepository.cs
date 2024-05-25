using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models;
using Shaghalni.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext context) : base(context) { }
    }
}
