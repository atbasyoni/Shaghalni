using Shaghalni.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
