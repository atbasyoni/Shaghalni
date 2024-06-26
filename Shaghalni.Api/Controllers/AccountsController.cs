﻿using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.Interfaces;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AccountsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepository.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            //SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(new { Message = result.Message, IsSuccessed = result.IsAuthenticated });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepository.LoginAsync(model);

            if(!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            await _authRepository.ConfirmEmail(userId, token);
            return Ok("Your email address has been successfully confirmed.");
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _authRepository.ForgetPassword(email);

            return Ok("If there is an account with the provided email address, we will send a message to it.");
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO model)
        {
            return Ok(await _authRepository.ResetPassword(model));
        }

        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDTO model)
        {
            var token = model.Token ?? Request.Cookies["RefershToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authRepository.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepository.AddRoleAsync(model);

            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expiration)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly =true,
                Expires = expiration.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
            };

            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }
    }
}
