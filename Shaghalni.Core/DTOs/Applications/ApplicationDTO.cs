using Shaghalni.Core.DTOs.Helpers;

namespace Shaghalni.Core.DTOs.Applications
{
    public class ApplicationDTO : BaseDTO
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime ApplyDate { get; set; }
        public string JobType { get; set; }
        public int Vacancies { get; set; }
        public string Status { get; set; }
        public bool IsArchived { get; set; }
    }
}
