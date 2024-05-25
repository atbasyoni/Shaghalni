using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class CompanyCity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
