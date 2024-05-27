using System.ComponentModel.DataAnnotations;

namespace Shaghalni.Core.DTOs.Helpers
{
    public class BaseDictionaryDTO : BaseDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }
    }
}
