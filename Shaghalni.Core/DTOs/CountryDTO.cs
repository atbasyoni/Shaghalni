using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs
{
    public class CountryDTO : BaseDictionaryDTO
    {

    }

    public class CreateCountryDTO
    {
        public string Name { get; set; }
    }
}
