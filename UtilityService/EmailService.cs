using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using RobotManagmentApi.Models;
using RobotManagmentApi.UtilityService;
using System;

namespace AngularAuthAPI.UtilityService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void sendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Lets Program", _config["EmailSettings:From"]));
            emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
            emailMessage.Subject = emailModel.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = emailModel.Content;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config["EmailSettings:SmtpServer"], int.Parse(_config["EmailSettings:Port"]), SecureSocketOptions.StartTls);
                    client.Authenticate(_config["EmailSettings:Username"], _config["EmailSettings:Password"]);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    // Handle the exception or log the error message
                    throw new Exception("Failed to send email.", ex);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
