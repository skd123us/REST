using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio.Library.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "AC4a9e04811b6f4a8b9dfa0bf71da8eb5e";
            const string authToken = "e22d498ee3c2b2f10b5d2078072ded5a";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+14044927564");
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+14707190137"),
                body: "All in the game, yo");

            Console.WriteLine(message.Sid);
        }
    }
}
