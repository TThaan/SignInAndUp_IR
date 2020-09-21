using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SignInAndUp_IR.Areas.Identity.Data;
using System.Threading.Tasks;

namespace SignInAndUp_IR.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _cfg;
        private readonly UserManager<User> _usermanager;

        public EmailSender(IConfiguration cfg, UserManager<User> usermanager)
        {
            _cfg = cfg;
            _usermanager = usermanager;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlContent)
        {
            User user = await _usermanager.FindByEmailAsync(email);

            EmailAddress from = new EmailAddress("joti24000@gmail.com", "SignInAndUp_IR");
            EmailAddress to = new EmailAddress(email, user.UserName);
            string textContent = htmlContent;
            SendGridMessage message = MailHelper.CreateSingleEmail(
                from, to, subject, textContent, htmlContent);

            //message.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            //message.SetClickTracking(false, false);

            string apiKey = _cfg["SendGridApiKey"];
            SendGridClient client = new SendGridClient(apiKey);
            await client.SendEmailAsync(message);
        }
    }
}
