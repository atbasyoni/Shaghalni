using Shaghalni.Core.Models.Applications;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Jobs
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public int NumberOfVacancies { get; set; }
        public int ViewedApplication { get; set; }
        public int WithdrawnApplications { get; set; }
        public int AcceptedApplications { get; set; }
        public int InConsiderationApplications { get; set; }
        public int RejectedApplications { get; set; }
        public int TotalApplications { get; set; }
        public bool IsOpen { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public JobDetails JobDetails { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? JobTypeId { get; set; }
        public JobType JobType { get; set; }

        public List<Application> Applications { get; set; }
        public List<JobSkill> JobSkills { get; set; }
    }
}
