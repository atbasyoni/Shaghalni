using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Helpers
{
    public class JWT
    {
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudience { get; set; } = null!;
        public double DurationInMintues { get; set; }
        public string Key { get; set; } = null!;
    }
}
