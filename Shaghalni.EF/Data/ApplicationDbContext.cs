using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shaghalni.Core.Models;
using Shaghalni.Core.Models.Accounts;
using Shaghalni.Core.Models.Applications;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Employees;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        }

        // Jobs
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }

        // Employees
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLink> EmployeeLinks { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeJobType> EmployeeJobTypes { get; set; }
        public DbSet<EmployeeJobCategory> EmployeeJobCategories { get; set; }

        // Companies
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCity> CompanyCities { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<CompanyLink> CompanyLinks { get; set; }
        public DbSet<CompanyManager> CompanyManagers { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyApplicationStatus> CompanyApplicationStatuses { get; set; }

        // Applications
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        // Other Entities
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CareerLevel> CareerLevels { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SalaryRate> SalaryRates { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
