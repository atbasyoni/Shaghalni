using Shaghalni.Core.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}
