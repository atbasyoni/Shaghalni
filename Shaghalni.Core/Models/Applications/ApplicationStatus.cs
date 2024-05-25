using Shaghalni.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Models.Applications
{
    public class ApplicationStatus : DictionaryTable
    {
        public List<Application> Applications { get; set; }
    }
}
