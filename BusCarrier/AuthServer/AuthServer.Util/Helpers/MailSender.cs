using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Util.Config;
using Microsoft.Extensions.Options;

namespace AuthServer.Util.Helpers
{
    public class MailSender : IMailSender
    {
        private readonly EmailConfig emailConfig;

        public MailSender(IOptions<EmailConfig> emailConfig)
        {
            this.emailConfig = emailConfig.Value;
        }

        public async Task SendMail(string address, string subject, string text)
        {
            var fromEmail = new MailAddress(emailConfig.Email, emailConfig.DisplayName);
            var toEmail = new MailAddress(address);
            var fromEmailPassword = emailConfig.Password;

            var smtp = new SmtpClient
            {
                Host = emailConfig.Host,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = text,
                IsBodyHtml = true
            };

            smtp.Send(message);
        }
    }
}