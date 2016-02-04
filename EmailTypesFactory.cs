using System.Collections.Generic;

namespace DDDEastAnglia.EmailSender
{
    internal class EmailTypesFactory
    {
        public static IDictionary<EmailTypes, EmailType> Create()
        {
            return new Dictionary<EmailTypes, EmailType>
            {
                {EmailTypes.Success, Success()},
                {EmailTypes.Reserve, Reserve()},
                {EmailTypes.Decline, Decline()}
            };
        }

        private static EmailType Success()
        {
            return new EmailType("SuccessEmail.html",
                @"select s.title, s.abstract, p.Name, p.EmailAddress, p.MobilePhone, p.TwitterHandle
from sessions s, UserProfiles p
where p.UserName = s.SpeakerUserName
and s.Selected = 1
order by p.Name asc");
        }

        private static EmailType Reserve()
        {
            return new EmailType("ReserveEmail.html",
                @"select s.title, s.abstract, p.Name, p.EmailAddress, p.MobilePhone, p.TwitterHandle
from sessions s, UserProfiles p
where p.UserName = s.SpeakerUserName
and s.Reserve = 1
order by p.Name asc");
        }

        private static EmailType Decline()
        {
            return new EmailType("DeclineEmail.html",
                @"select distinct (p.Name), p.EmailAddress, p.MobilePhone, p.TwitterHandle, '' as title
from sessions s, UserProfiles p
where p.UserName = s.SpeakerUserName
and s.declinedandnotalreadycontacted = 1
order by p.Name asc");
        }
    }
}
