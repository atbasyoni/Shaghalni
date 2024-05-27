using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Helpers;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Applications
{
    public class Application : BaseEntity
    {
        public DateTime ApplyDate { get; set; }
        public DateTime ArchiveDate { get; set; }
        public DateTime WithdrawDate { get; set; }
        public string Status { get; set; }
        public bool IsViewed { get; set; }
        public bool IsWithdrawn { get; set; }
        public bool IsArchived { get; set; }
        public string WithdrawReason { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? ApplicationStatusId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        public int? CompanyApplicationStatusId { get; set; }
        public CompanyApplicationStatus CompanyApplicationStatus { get; set; }
    }
}
