using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.Helpers;
using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Accounts;
using Shaghalni.EF.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Shaghalni.EF.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSenderRepository _emailSender;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JWT _jwt;
        private readonly JwtHandler _jwtHandler;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSenderRepository emailSender,
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IOptions<JWT> jwt,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwt = jwt.Value;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            var response = new AuthResponseDTO();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                response.Message = "Email or Password is incorrect";
                return response;
            }

            var token = await CreatJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            response.UserName = user.UserName;
            response.Email = user.Email;
            response.IsAuthenticated = true;
            response.Roles = roles.ToList();
            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.ExpiresOn = token.ValidTo;

            if (user.RefreshTokens.Any(r => r.IsActive))
            {
                var activeRefershToken = user.RefreshTokens.SingleOrDefault(r => r.IsActive);
                response.RefreshToken = activeRefershToken.Token;
                response.RefreshTokenExpiration = activeRefershToken.ExpiredOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.ExpiredOn;
            }

            return response;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO model)
        {
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthResponseDTO() { Message = "Username is alerady registered!" };

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthResponseDTO() { Message = "Email is already registered!" };

            var user = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthResponseDTO() { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlCodedEmailConfirmationToken = CodeTokenToURL(emailConfirmationToken);
            _emailSender.ConfirmEmailEmail(urlCodedEmailConfirmationToken, user);

            return new AuthResponseDTO
            {
                IsAuthenticated = true,
                Message = "User registered successfully",
            };

        }

        public async Task<string> AddRoleAsync(RoleDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            
            if (user is null || await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong!";
        }

        public async Task<string> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return "Invalid UserId";
            }

            if (user.EmailConfirmed)
            {
                return "The email has already been confirmed.";
            }

            var decodedToken = DecodeToken(token);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                return "An error occurred in your email confirmation.";
            }

            return result.ToString();
        }

        public async Task ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                _emailSender.ResetPasswordEmail(token, user);
            }

        }

        public async Task<string> ResetPassword(ResetPasswordDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return "An error occurred while retrieving the user.";
            }

            if (model.Password != model.ConfirmPassword)
            {
                return "The Password doesn't match confirmed password.";
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token!, model.Password!);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return errors;
            }

            return result.ToString();
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user is null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
           
            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        private string CodeTokenToURL(string token)
        {
            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            return WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
        }

        public string DecodeToken(string token)
        {
            var tokenDecodedBytes = WebEncoders.Base64UrlDecode(token);
            return Encoding.UTF8.GetString(tokenDecodedBytes);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var RandomNumber = new Byte[32];
            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(RandomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpiredOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow,
            };
        }


        private async Task<JwtSecurityToken> CreatJwtToken(ApplicationUser user)
        {
            return await _jwtHandler.GetTokenAsync(user);
        }
    }
}
