using Shaghalni.Core.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<string> CreateRoleAsync(CreateRoleDTO role);
        Task<IEnumerable<RoleResponseDTO>> GetRolesAsync();
        Task<string> DeleteRoleAsync(string roleId);
        Task<string> AssignRoleAsync(RoleDTO model);
    }
}
