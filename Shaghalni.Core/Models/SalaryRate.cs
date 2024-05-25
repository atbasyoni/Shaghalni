using Shaghalni.Core.Models.Helpers;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models
{
    public class SalaryRate : DictionaryTable
    {
        public List<JobDetails> Job_Details { get; set; }
    }
}
