using Shaghalni.Core.Models.Accounts;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class CompanyManager : BaseEntity
    {
        public string Title { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
