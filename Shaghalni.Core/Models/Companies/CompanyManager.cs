using Shaghalni.Core.Models.Accounts;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Companies
{
    public class CompanyManager : BaseEntity
    {
        public string Title { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
