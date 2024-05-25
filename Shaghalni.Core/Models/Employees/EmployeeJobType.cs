using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Employees
{
    public class EmployeeJobType
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int JobTypeId { get; set; }
        public virtual JobType JobType { get;}
    }
}
