using Shaghalni.Core.DTOs.Helpers;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Jobs;
using System.ComponentModel.DataAnnotations;

namespace Shaghalni.Core.DTOs.Companies
{
    public class CompanyDTO : BaseDictionaryDTO
    {
        [Url]
        public string Logo { get; set; }

        [StringLength(1000, ErrorMessage = "About Us section can't be more than 1000 characters.")]
        public string AboutUs { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime YearFounded { get; set; }

        public int CompanyIndustryId { get; set; }

        public int CompanySizeId { get; set; }

        public int CompanyTypeId { get; set; }

        public List<CompanyLink> CompanyLinks { get; set; }
        public List<Job> Jobs { get; set; }
        public List<CompanyManager> Managers { get; set; }
    }
}
