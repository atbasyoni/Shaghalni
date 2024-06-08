﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.Core.DTOs.Accounts
{
    public class AuthResponseDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public List<string>? Roles { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
