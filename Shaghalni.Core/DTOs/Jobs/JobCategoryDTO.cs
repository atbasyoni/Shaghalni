using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Jobs
{
    public class JobCategoryDTO : BaseDictionaryDTO
    {

    }

    public class CreateJobCategoryDTO
    {
        public string Name { get; set; }
    }
}
