using System;
using System.Net;
using System.Net.Mail;

namespace DDDEastAnglia.EmailSender
{
    internal class EmailSender
    {
        private readonly Configuration configuration;
        private readonly SmtpClient client;

        public EmailSender(Configuration configuration)
        {
            this.configuration = configuration;

            client = new SmtpClient(configuration.MailServer_Host, configuration.MailServer_Port)
            {
                Credentials = new NetworkCredential(configuration.MailServer_Username, configuration.MailServer_Password)
            };
        }

        public void SendEmail(string toEmailAddress, string body)
        {
            Console.WriteLine("Sending email to " + toEmailAddress);
            var from = new MailAddress(configuration.From_EmailAddress, configuration.From_Name);
            var to = new MailAddress(toEmailAddress);
            var message = new MailMessage(from, to);

            if (!string.IsNullOrWhiteSpace(configuration.BCC_EmailAddress))
            {
                message.Bcc.Add(configuration.BCC_EmailAddress);
            }

            message.IsBodyHtml = true;
            message.Subject = configuration.Email_SubjectLine;
            message.Body = body;

            client.Send(message);
        }
    }
}
