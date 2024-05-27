using Shaghalni.Api.Enums;
using Shaghalni.Core.DTOs.Helpers;
using Shaghalni.Core.DTOs.Jobs;
using System.ComponentModel.DataAnnotations;

namespace Shaghalni.Core.DTOs.Employees
{
    public class EmployeeDTO : BaseDTO
    {
        [Url]
        public string CV { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        public string SecondaryPhoneNumber { get; set; }

        [Range(0, 50, ErrorMessage = "Experience years must be between 0 and 50.")]
        public int ExperienceYears { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public bool IsWillingToRelocate { get; set; }

        [Required]
        public MilitaryStatus MilitaryStatus { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Minimum salary must be a positive number.")]
        public int MinSalary { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nationality length can't be more than 100.")]
        public string Nationality { get; set; }

        [Url]
        public string Photo { get; set; }

        [StringLength(1000, ErrorMessage = "Summary length can't be more than 1000.")]
        public string Summary { get; set; }

        [Required]
        public int CareerLevelId { get; set; }
        public string CareerLevelName { get; set; }

        [Required]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [Required]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        [Required]
        public int EducationLevelId { get; set; }
        public string EducationLevelName { get; set; }

        [Required]
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public List<JobCategoryDTO> JobCategories { get; set; }
        public List<EmployeeLanguageDTO> EmployeeLanguages { get; set; }
        public List<SkillDTO> Skills { get; set; }
        public List<JobTypeDTO> JobTypes { get; set; }
        public List<EmployeeLinkDTO> EmployeeLinks { get; set; }
    }
}
