using Shaghalni.Core.DTOs.Helpers;

namespace Shaghalni.Core.DTOs.Companies
{
    public class CompanyProfileDTO : BaseDictionaryDTO
    {
        public string Logo { get; set; }
        public string AboutUs { get; set; }
        public DateTime YearFounded { get; set; }
        public string PhoneNumber { get; set; }

        public int CompanySizeId { get; set; }
        public CompanySizeDTO CompanySize { get; set; }

        public int CompanyTypeId { get; set; }
        public CompanyTypeDTO CompanyType { get; set; }

        public int CompanyIndustryId { get; set; }
        public CompanyIndustryDTO CompanyIndustry { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public List<CompanyLinkDTO> CompanyLinks { get; set; }
    }
}
