using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace DDDEastAnglia.EmailSender
{
    internal class Program
    {
        private readonly Configuration configuration;
        private readonly EmailSender emailSender;

        public Program(Configuration configuration)
        {
            this.configuration = configuration;
            emailSender = new EmailSender(configuration);
        }

        public void Run(EmailTypes emailTypeToSend)
        {
            var emailType = EmailTypesFactory.Create()[emailTypeToSend];

            string templatePath = Path.Combine(configuration.Templates_Directory, emailType.EmailTemplateFilename);
            string templateHtml = File.ReadAllText(templatePath);

            using (var connection = new SqlConnection(configuration.Database_ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = emailType.Query;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string speakerName = reader.GetString(reader.GetOrdinal("Name"));
                            string speakerEmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                            string sessionTitle = reader.GetString(reader.GetOrdinal("Title"));

                            string emailContents = PrepeareEmail(emailTypeToSend, templateHtml, speakerName, sessionTitle);
                            emailSender.SendEmail(speakerEmailAddress, emailContents);
                        }
                    }
                }
            }
        }

        private string PrepeareEmail(EmailTypes emailTypeToSend, string templateHtml, string speakerName, string sessionTitle)
        {
            string speakerFirstName = speakerName.Split(' ').First();
            string html = templateHtml.Replace(configuration.Email_SpeakerNamePlaceholder, speakerFirstName)
                                      .Replace(configuration.Email_SessionTitlePlaceholder, sessionTitle);

            var directory = Path.Combine(configuration.SentEmails_OutputDirectory, emailTypeToSend.ToString());
            Directory.CreateDirectory(directory);

            string path = Path.Combine(directory, speakerName) + ".html";
            File.WriteAllText(path, html);

            return html;
        }
    }
}
