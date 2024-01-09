using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using Shop.Core.Dto.EmailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MailKit;

namespace Shop.ApplicationServices.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto req)
        {
            var email = new MimeMessage();

            var host_ = _config.GetSection("EmailHost").Value;
            var username_ = _config.GetSection("EmailUsername").Value;
            var password_ = _config.GetSection("EmailPassword").Value;

            email.From.Add(MailboxAddress.Parse(username_));
            email.To.Add(MailboxAddress.Parse(req.To));

            email.Subject = req.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = req.Body
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(host_, 587, SecureSocketOptions.StartTls);

  
                smtp.Authenticate(username_, password_);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
