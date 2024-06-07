using Shaghalni.Core.DTOs.Helpers;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Jobs;
using Shaghalni.Core.Models;

namespace Shaghalni.Core.DTOs.Jobs
{
    public class JobDTO : BaseDTO
    {
        public string Title { get; set; }
        public int NumberOfVacancies { get; set; }
        public int ViewedApplication { get; set; } = 0;
        public int WithdrawnApplications { get; set; } = 0;
        public int AcceptedApplications { get; set; } = 0;
        public int InConsiderationApplications { get; set; } = 0;
        public int RejectedApplications { get; set; } = 0;
        public int TotalApplications { get; set; } = 0;
        public bool IsOpen { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
        //public JobDetails JobDetails { get; set; }

        //public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }

        //public int? CityId { get; set; }
        public string JobCityName { get; set; }

        //public int? CountryId { get; set; }
        public string JobCountryName { get; set; }

        //public int? JobTypeId { get; set; }
        public string JobTypeName { get; set; }

        //public List<Application> Applications { get; set; }
        //public List<JobSkill> JobSkills { get; set; }
    }
}
