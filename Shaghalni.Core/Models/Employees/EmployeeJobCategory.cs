using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Employees
{
    public class EmployeeJobCategory
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}
