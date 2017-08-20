using System.Threading.Tasks;
using OfficeClip.OpenSource.Integration.Rest.Library.Sms;
using OfficeClip.OpenSource.Integration.Rest.Library;

namespace Rest.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetMessageInfo().Wait();
        }

        public static async Task<TwilioMessage> GetMessageInfo()
        {
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            var twilioMessage = await Twilio.GetMessage(smsInfo, "SM52ff57b14c4145478967d157bbf8d06a");
            return twilioMessage;
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
