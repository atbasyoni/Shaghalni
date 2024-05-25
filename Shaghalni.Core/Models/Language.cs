using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models
{
    public class Language : DictionaryTable
    {
        public List<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
