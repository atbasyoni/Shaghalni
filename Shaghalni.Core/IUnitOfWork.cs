using Shaghalni.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationRepository Applications { get; }
        ICompanyRepository Companies { get; }
        IEmployeeRepository Employees { get; }
        IJobRepository Jobs { get; }
        IJobDetailsRepository JobDetails { get; }
        ISkillRepository Skills { get; }
        Task<int> Complete();
    }
}
