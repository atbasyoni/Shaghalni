﻿using System.ComponentModel.DataAnnotations;

namespace Shaghalni.Core.DTOs.Accounts
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}