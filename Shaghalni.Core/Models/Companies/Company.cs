using Shaghalni.Core.Models.Helpers;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class Company : DictionaryTable
    {
        public string Logo { get; set; }
        public string AboutUs { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime YearFounded { get; set; }

        public int CompanyIndustryId { get; set; }
        public virtual CompanyIndustry CompanyIndustry { get; set; }

        public int CompanySizeId { get; set; }
        public virtual CompanySize CompanySize { get; set; }

        public int CompanyTypeId { get; set; }
        public virtual CompanyType CompanyType { get; set; }

        public List<CompanyLink> CompanyLinks { get; set; }
        public List<Job> Jobs { get; set; }
        public List<CompanyManager> Managers { get; set; }
    }
}
