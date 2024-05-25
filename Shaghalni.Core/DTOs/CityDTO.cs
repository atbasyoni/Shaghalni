using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs
{
    public class CityDTO : BaseDictionaryDTO
    {
        public int CountryId { get; set; }
    }

    public class CreateCityDTO
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
