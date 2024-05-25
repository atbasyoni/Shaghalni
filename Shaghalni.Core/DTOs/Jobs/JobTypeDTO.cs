using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Jobs
{
    public class JobTypeDTO : BaseDictionaryDTO
    {

    }

    public class CreateJobTypeDTO
    {
        public string Name { get; set; }
    }
}
