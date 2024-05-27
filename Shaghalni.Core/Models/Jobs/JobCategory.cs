using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shaghalni.Core.Models.Jobs
{
    public class JobCategory : DictionaryTable
    {
        public List<EmployeeJobCategory> EmployeeJobCategories { get; set; }
        public List<JobDetails> Job_Details { get; set; }
    }
}
