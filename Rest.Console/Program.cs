using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Library.Sms;
using System.Web;
using Rest.Library;

namespace Rest.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SendMessage().Wait();
        }

        public static async Task SendMessage()
        {
            var twilioMessage = new TwilioMessage();
            twilioMessage.ReadFromConfiguration();
            twilioMessage.Message = "All in the game";           
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            await Twilio.SendMessage(smsInfo, twilioMessage);
        }
    }
}
