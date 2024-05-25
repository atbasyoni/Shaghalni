using Shaghalni.Core;
using Shaghalni.Core.Interfaces;
using Shaghalni.EF.Data;
using Shaghalni.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICompanyRepository Companies { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IJobRepository Jobs { get; private set; }
        public IJobDetailsRepository JobDetails { get; private set; }
        public ISkillRepository Skills { get; private set; }
        public IApplicationRepository Applications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(context);
            Employees = new EmployeeRepository(context);
            Jobs = new JobRepository(context);
            JobDetails = new JobDetailsRepository(context);
            Skills = new SkillRepository(context);
            Applications =  new ApplicationRepository(context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
