using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.Models.Accounts;

namespace Shaghalni.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthModel> RegisterAsync(RegisterDTO model);
        Task<AuthModel> LoginAsync(LoginDTO model);
        Task<string> AddRoleAsync(RoleDTO model);
        Task<bool> RevokeTokenAsync(string token);
        Task<string> ConfirmEmail(string userId, string token);
        Task ForgetPassword(string email);
        Task<string> ResetPassword(ResetPasswordDTO model);
    }
}
