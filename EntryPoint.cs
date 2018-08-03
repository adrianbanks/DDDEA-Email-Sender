using System;

namespace DDDEastAnglia.EmailSender
{
    internal static class EntryPoint
    {
        internal static void Main(string[] args)
        {
            try
            {
                var emailType = GetEmailType(args);

                if (emailType == null)
                {
                    Console.WriteLine("Could not figure out email type. No emails have been sent.");
                    return;
                }

                Console.WriteLine($"Sending {emailType} emails...");
                var program = new Program(new Configuration());
                program.Run(emailType.Value);

                Console.WriteLine("Emails sent successfully");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error sending emails:");
                Console.WriteLine(exception);
            }
        }

        private static EmailTypes? GetEmailType(string[] args)
        {
            if (args.Length != 1)
            {
                return null;
            }

            if (Enum.TryParse(args[0], true, out EmailTypes emailType))
            {
                return emailType;
            }

            return null;
        }
    }
}
