using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs
{
    public class SkillDTO : BaseDictionaryDTO
    {

    }

    public class CreateSkillDTO
    {
        public string Name { get; set; }
    }
}
