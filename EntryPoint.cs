using System;

namespace DDDEastAnglia.EmailSender
{
    internal static class EntryPoint
    {
        internal static void Main()
        {
            Console.WriteLine("Press enter to send emails...");
            Console.ReadLine();

            try
            {
                var program = new Program(new Configuration());
                program.Run(EmailTypes.XXX);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
