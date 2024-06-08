using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shaghalni.EF.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly IEmailRepository _emailRepository;

        public EmailSenderRepository(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public void ConfirmEmailEmail(string token, ApplicationUser user)
        {
            if (_emailRepository.IsEmailConfigurationSet())
            {
                var confirmationLink = $"http://localhost:4200/ConfirmEmail?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
                var emailBody = $"<h1>Welcome to Shaghalni!</h1><br>" + $"<p>Please confirm your email address. You’re receiving this message because you’ve signed up for a Shaghalni account.</p><br>" + $"<a class='btn btn-primary' href='{confirmationLink}'>Verify Email</a><br>" + $"<p>If the button above is not clickable, copy-paste the following url into your web browser:</p><br>" + $"<a href='{confirmationLink}'>{confirmationLink}</a>";

                _emailRepository.SendEmail(user.Email, "Shaghalni - Confirm email address", emailBody);
            }

        }

        public void ResetPasswordEmail(string token, ApplicationUser user)
        {
            if (_emailRepository.IsEmailConfigurationSet())
            {
                var resetLink = $"http://localhost:4200/ResetPassword?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
                var emailBody = $"To reset your password, click <a href='{resetLink}'>here</a>.";
                _emailRepository.SendEmail(user.Email, "Reset Password", emailBody);
            }
        }
    }
}
