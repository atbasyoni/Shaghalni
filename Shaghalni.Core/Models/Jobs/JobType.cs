using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Jobs
{
    public class JobType : DictionaryTable
    {
        public List<Job> Jobs { get; set; }
        public List<EmployeeJobType> EmployeeJobTypes { get; set; }
    }
}
