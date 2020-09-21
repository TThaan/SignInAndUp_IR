using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace SignInAndUp_IR.Services
{
    /// <summary>
    /// custom IEmailSender
    /// </summary>
    public interface IMailService
    {
        Task<HttpStatusCode> SendEmailAsync(string receiverMailAddress, string receiverName, string subject, string htmlContent);
    }

    public class SendGridMailService : IMailService
    {
        private readonly IConfiguration _cfg;

        public SendGridMailService(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        public async Task<HttpStatusCode> SendEmailAsync(string receiverMailAddress, string receiverName, string subject, string htmlContent)
        {
            EmailAddress from = new EmailAddress("joti24000@gmail.com", "SignInAndUp_IR");
            EmailAddress to = new EmailAddress(receiverMailAddress, receiverName);
            string textContent = "some text";
            SendGridMessage message = MailHelper.CreateSingleEmail(
                from, to, subject, textContent, htmlContent);

            string apiKey = _cfg["SendGridApiKey"];
            SendGridClient client = new SendGridClient(apiKey);
            var result = await client.SendEmailAsync(message);
            return result.StatusCode;
        }
    }
}
