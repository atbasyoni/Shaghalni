using Microsoft.AspNetCore.Identity;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Accounts
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public CompanyManager Manager { get; set; }
    }
}
