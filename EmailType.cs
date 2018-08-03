namespace DDDEastAnglia.EmailSender
{
    internal class EmailType
    {
        public string EmailTemplateFilename { get; }
        public string Query { get; }

        public EmailType(string emailTemplateFilename, string query)
        {
            EmailTemplateFilename = emailTemplateFilename;
            Query = query;
        }
    }
}
