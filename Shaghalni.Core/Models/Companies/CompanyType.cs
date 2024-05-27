using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class CompanyType : DictionaryTable
    {
        public List<Company> Companies { get; set; }
    }
}
