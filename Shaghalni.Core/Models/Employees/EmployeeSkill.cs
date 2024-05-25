using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Employees
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
