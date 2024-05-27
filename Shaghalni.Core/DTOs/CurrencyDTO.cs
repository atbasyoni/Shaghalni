using Shaghalni.Core.DTOs.Helpers;

namespace Shaghalni.Core.DTOs
{
    public class CurrencyDTO : BaseDictionaryDTO
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
    }

    public class CreateCurrencyDTO
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
    }
}
