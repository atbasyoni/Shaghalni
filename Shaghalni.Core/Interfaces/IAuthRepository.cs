using Shaghalni.Core.DTOs.Accounts;

namespace Shaghalni.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO model);
        Task<AuthResponseDTO> LoginAsync(LoginRequestDTO model);
        Task<string> AddRoleAsync(RoleDTO model);
        Task<bool> RevokeTokenAsync(string token);
        Task<string> ConfirmEmail(string userId, string token);
        Task ForgetPassword(string email);
        Task<string> ResetPassword(ResetPasswordDTO model);
    }
}
