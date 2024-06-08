using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> CreateRoleAsync(CreateRoleDTO role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role.RoleName);

            if (roleExists)
                return "Role already exist!";

            var result = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

            if (!result.Succeeded)
                return "Role creation failed!";

            return "Role created successfully";
        }

        public async Task<IEnumerable<RoleResponseDTO>> GetRolesAsync()
        {
            return await _roleManager.Roles.Select(r => new RoleResponseDTO
            {
                Id = r.Id,
                Name = r.Name,
                TotalUsers = _userManager.GetUsersInRoleAsync(r.Name).Result.Count()
            }).ToListAsync();
        }

        public async Task<string> AssignRoleAsync(RoleDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
                return "User not found!";

            var role = await _roleManager.FindByNameAsync(model.Role);

            if (role is null)
                return "Role not found!";

            var result = await _userManager.AddToRoleAsync(user, role.Name!);

            if (!result.Succeeded)
                return result.Errors.FirstOrDefault().Description;

            return "Role assigned sucessfully";
        }

        public async Task<string> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
                return "Role not found!";

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
                return "Role deletion failed!";

            return "Role deleted successfully.";
        }
    }
}
