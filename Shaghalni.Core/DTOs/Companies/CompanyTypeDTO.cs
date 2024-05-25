using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Companies
{
    public class CompanyTypeDTO : BaseDictionaryDTO
    {

    }

    public class CreateCompanyTypeDTO
    {
        public string Name { get; set; }
    }
}
