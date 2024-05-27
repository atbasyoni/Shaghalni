using Shaghalni.Core.DTOs.Helpers;

namespace Shaghalni.Core.DTOs.Jobs
{
    public class JobDetailsDTO : BaseDTO
    {
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public string CareerLevelName { get; set; }
        public string EducationLevelName { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public string SalaryCurrencyName { get; set; }
        public string SalaryCurrencySymbol { get; set; }
        public string SalaryCurrencyCode { get; set; }
        public string SalaryRate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public DateTime CreatedDate { get; set; }

        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobCountry { get; set; }
        public string JobCity { get; set; }
        public string JobType { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime YearFounded { get; set; }
    }
}
