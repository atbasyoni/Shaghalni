using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Jobs
{
    public class JobDetails : BaseEntity
    {
        public string Description { get; set; }
        public string Requirments { get; set; }
        public string Responsibilities { get; set; }
        public int ExperienceMin { get; set; }
        public int ExperienceMax { get; set; }
        public int SalaryMax { get; set; }

        public int SalaryRateId { get; set; }
        public virtual SalaryRate SalaryRate { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int CareerLevelId { get; set; }
        public virtual CareerLevel CareerLevel { get; set; }

        public int EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

        public int JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }

        public int SalaryCurrencyId { get; set; }
        public virtual Currency SalaryCurrency { get; set; }
    }
}
