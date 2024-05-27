namespace Shaghalni.Core.Interfaces
{
    public interface IEmailRepository
    {
        public void SendEmail(string to, string subject, string body);
        public bool IsEmailConfigurationSet();
    }
}
