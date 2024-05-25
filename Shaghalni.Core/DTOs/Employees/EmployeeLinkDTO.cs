using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Employees
{
    public class EmployeeLinkDTO : BaseDictionaryDTO
    {
        public string Link { get; set; }
    }

    public class CreateEmployeeLinkDTO
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
