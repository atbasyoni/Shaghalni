using Shaghalni.Core.Models.Accounts;

namespace Shaghalni.Core.Interfaces
{
    public interface IEmailSenderRepository
    {
        void ResetPasswordEmail(string token, ApplicationUser user);
        void ConfirmEmailEmail(string token, ApplicationUser user);
    }
}
