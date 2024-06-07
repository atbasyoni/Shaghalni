using Shaghalni.Core.Models.Helpers;

namespace Shaghalni.Core.Models.Jobs
{
    public class JobDetails : BaseEntity
    {
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int SalaryRateId { get; set; }
        public SalaryRate SalaryRate { get; set; }

        public int? CareerLevelId { get; set; }
        public CareerLevel CareerLevel { get; set; }

        public int? EducationLevelId { get; set; }
        public  EducationLevel EducationLevel { get; set; }

        public int? JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        public int? SalaryCurrencyId { get; set; }
        public Currency SalaryCurrency { get; set; }
    }
}
