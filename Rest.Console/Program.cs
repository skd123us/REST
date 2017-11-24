﻿using System.Threading.Tasks;
using OfficeClip.OpenSource.Integration.Rest.Library.Sms;
using OfficeClip.OpenSource.Integration.Rest.Library;

namespace Rest.Console
{
    public class Program
    {
        static TwilioMessage message;
        public static void Main(string[] args)
        {
            //SendMessage().Wait();
            GetMessageInfo().Wait();

        }

        public static async Task<TwilioMessage> GetMessageInfo()
        {
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            var twilioMessage = await Twilio.GetMessage(smsInfo, "SM1e8208f4b4e44720bafc9ea0334eb72d");
            return twilioMessage;
        }

        public static async Task SendMessage()
        {
            var twilioMessage = new TwilioMessage();
            twilioMessage.ReadFromConfiguration();
            twilioMessage.Message = "All in the game";           
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            message = await Twilio.SendMessage(smsInfo, twilioMessage);
        }
    }
}
