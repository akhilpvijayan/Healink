using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Healink.Business.Services.Services
{
    public class ConfigurationService : IConfigurationService
    {
        #region properties
        private readonly IConfiguration _config;
        #endregion

        #region constructor
        public ConfigurationService(IConfiguration config)
        {
            _config = config;
        }
        #endregion
        #region public functions
        public void SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:emailUsername").Value));
            email.To.Add(MailboxAddress.Parse("akhilpvofficial8@gmail.com"));

            email.Subject = "Test Email";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("Email:emailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("Email:emailUsername").Value, _config.GetSection("Email:emailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        #endregion
    }
}
