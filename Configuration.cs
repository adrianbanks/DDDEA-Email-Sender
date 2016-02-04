using System.Configuration;

namespace DDDEastAnglia.EmailSender
{
    internal class Configuration
    {
        public string Database_ConnectionString
        {
            get { return GetSetting("Database_ConnectionString"); }
        }

        public string Templates_Directory
        {
            get { return GetSetting("Templates_Directory"); }
        }

        public string MailServer_Host
        {
            get { return GetSetting("MailServer_Host"); }
        }

        public int MailServer_Port
        {
            get { return int.Parse(GetSetting("MailServer_Port")); }
        }

        public string MailServer_Username
        {
            get { return GetSetting("MailServer_Username"); }
        }

        public string MailServer_Password
        {
            get { return GetSetting("MailServer_Password"); }
        }

        public string From_Name
        {
            get { return GetSetting("From_Name"); }
        }

        public string From_EmailAddress
        {
            get { return GetSetting("From_EmailAddress"); }
        }

        public string BCC_EmailAddress
        {
            get { return GetSetting("BCC_EmailAddress"); }
        }

        public string Email_SubjectLine
        {
            get { return GetSetting("Email_SubjectLine"); }
        }

        public string Email_SpeakerNamePlaceholder
        {
            get { return GetSetting("Email_SpeakerNamePlaceholder"); }
        }

        public string Email_SessionTitlePlaceholder
        {
            get { return GetSetting("Email_SessionTitlePlaceholder"); }
        }

        public string SentEmails_OutputDirectory
        {
            get { return GetSetting("SentEmails_OutputDirectory"); }
        }

        private string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
