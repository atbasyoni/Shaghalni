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
    public class Country : DictionaryTable
    {
        public List<Employee> Employees { get; set; }
        public List<Job> Jobs { get; set; }
        public List<City> Cities { get; set; }

    }
}
