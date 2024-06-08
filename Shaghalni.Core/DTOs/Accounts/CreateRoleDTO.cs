using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Accounts
{
    public class CreateRoleDTO
    {
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; }
    }
}
