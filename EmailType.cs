namespace DDDEastAnglia.EmailSender
{
    internal class EmailType
    {
        public string EmailTemplateFilename { get { return emailTemplateFilename; } }
        private readonly string emailTemplateFilename;

        public string Query { get { return query; } }
        private readonly string query;

        public EmailType(string emailTemplateFilename, string query)
        {
            this.emailTemplateFilename = emailTemplateFilename;
            this.query = query;
        }
    }
}
