using MailKit.Net.Smtp;
using MimeKit;
using MovieProps.BLL.Contract.Helpers;
using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Helpers
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_emailConfig.From));
                email.To.Add(MailboxAddress.Parse(message.To));
                email.Subject = message.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = GetHtml(message.Content ?? "")};

                using var smtp = new SmtpClient();
                smtp.Connect(_emailConfig.SmtpServer, _emailConfig.Port??0, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private string GetHtml(string text)
        {
            return $@"
<div style=""position: fixed; top: 0; left: 0; width: 100%; height: 100%; display: flex; justify-content: center;"">
    <img src=""https://cdn.vox-cdn.com/thumbor/5w9FJ8Fimki197z9orQZnJ3CyMo=/1400x1050/filters:format(png)/cdn.vox-cdn.com/uploads/chorus_asset/file/24415978/rick_and_morty_s4_image.png"" />
</div>
<div po></div>
<div style=""position: fixed; top: 0; left: 0; width: 100%; height: 100%; display: flex; justify-content: center; align-items: center;"">
    <h1 style=""background-color: rgba(0, 0, 0, 0.8); border-radius: 1rem; color: rgba(255, 255, 255, 0.9); padding: 2rem;"">{text}</h1>
</div>
";

        }

        
    }
}
