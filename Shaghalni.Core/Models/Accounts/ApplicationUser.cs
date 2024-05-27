using Microsoft.AspNetCore.Identity;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Employees;

namespace Shaghalni.Core.Models.Accounts
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public List<RefreshToken> RefreshTokens { get; set; }

        public Employee Employee { get; set; }
        public CompanyManager CompanyManager { get; set; }
    }
}
