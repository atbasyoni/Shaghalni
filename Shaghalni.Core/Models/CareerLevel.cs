using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Helpers;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models
{
    public class CareerLevel : DictionaryTable
    {
        public List<Employee>? Employees { get; set; }
        public List<JobDetails> Job_Details { get; set; }
    }
}
