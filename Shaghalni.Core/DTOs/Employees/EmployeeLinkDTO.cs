using Shaghalni.Core.DTOs.Helpers;

namespace Shaghalni.Core.DTOs.Employees
{
    public class EmployeeLinkDTO : BaseDictionaryDTO
    {
        public string Link { get; set; }
    }

    public class CreateEmployeeLinkDTO
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
