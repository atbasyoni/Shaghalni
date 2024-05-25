using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Shaghalni.Core.Models.Accounts;
using Shaghalni.Core.Models.Applications;
using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Employees
{
    public class Employee : BaseEntity
    {
        public string CV { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public int ExperienceYears { get; set; }
        public string Gender { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public string MilitaryStatus { get; set; }
        public int MinSalary { get; set; }
        public string Nationality { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }

        public int CareerLevelId { get; set; }
        public virtual CareerLevel CareerLevel { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public List<EmployeeJobCategory> EmployeeJobCategories { get; set; }
        public List<EmployeeLanguage> EmployeeLanguages { get; set; }
        public List<EmployeeSkill> EmployeeSkills { get; set; }
        public List<EmployeeJobType> EmployeeJobType { get; set; }
        public List<EmployeeLink> EmployeeLink { get; set; }
        public List<Application> EmployeeApplications { get; set; }
    }
}
