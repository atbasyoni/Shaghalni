using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Jobs
{
    public class JobSkill
    {
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
