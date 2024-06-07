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
        public int YearFounded { get; set; }

        public int? CompanyIndustryId { get; set; }
        public CompanyIndustry CompanyIndustry { get; set; }

        public int? CompanySizeId { get; set; }
        public CompanySize CompanySize { get; set; }

        public int? CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }

        public List<Job> Jobs { get; set; }
        public List<CompanyLink> Links { get; set; }
        public List<CompanyManager> Managers { get; set; }
        public List<CompanyCity> Locations { get; set; }
    }
}
