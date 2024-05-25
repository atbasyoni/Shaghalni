using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Employees
{
    public class EmployeeLanguage
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual int LanguageId { get; set;}
        public virtual Language Language { get; set;}
    }
}
