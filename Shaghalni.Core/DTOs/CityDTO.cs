using Shaghalni.Core.DTOs.Helpers;

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
