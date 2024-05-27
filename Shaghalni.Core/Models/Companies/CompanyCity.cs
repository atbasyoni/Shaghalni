using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class CompanyCity
    {
        public int CityId { get; set; }
        public City City { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
