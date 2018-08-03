using System.Configuration;

namespace DDDEastAnglia.EmailSender
{
    internal class Configuration
    {
        public string Database_ConnectionString => GetSetting("Database_ConnectionString");

        public string Templates_Directory => GetSetting("Templates_Directory");

        public string MailServer_Host => GetSetting("MailServer_Host");

        public int MailServer_Port => int.Parse(GetSetting("MailServer_Port"));

        public string MailServer_Username => GetSetting("MailServer_Username");

        public string MailServer_Password => GetSetting("MailServer_Password");

        public string From_Name => GetSetting("From_Name");

        public string From_EmailAddress => GetSetting("From_EmailAddress");

        public string BCC_EmailAddress => GetSetting("BCC_EmailAddress");

        public string Email_SubjectLine => GetSetting("Email_SubjectLine");

        public string Email_SpeakerNamePlaceholder => GetSetting("Email_SpeakerNamePlaceholder");

        public string Email_SessionTitlePlaceholder => GetSetting("Email_SessionTitlePlaceholder");

        public string SentEmails_OutputDirectory => GetSetting("SentEmails_OutputDirectory");

        private string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
