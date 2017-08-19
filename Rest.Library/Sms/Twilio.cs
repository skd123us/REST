using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace Rest.Library.Sms
{
    public class Twilio
    {
        public const string SmsUrl = "https://api.twilio.com/2010-04-01/Accounts/{0}/Messages";

        public static async Task<TwilioMessage> SendMessage(
            RestCredentialInfo restCredentialInfo,
            TwilioMessage twilioMessage)
        {
            var sms = new Rest(
                restCredentialInfo.AccountId,
                restCredentialInfo.SecretKey);
            var url = string.Format(
                                    SmsUrl,
                                    restCredentialInfo.AccountId);
            var content = new StringContent(twilioMessage.ToMessageString());
            var response = await sms.PostAsync(
                                               url,
                                               content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(
                           responseContent);

            if (!response.IsSuccessStatusCode)
            {
                var restException = new TwilioException();
                try
                {
                    restException.Code = Convert.ToInt32(
                                                         xmlDoc.SelectSingleNode(
                                                                                 "TwilioResponse/RestException/Code")
                                                               .InnerText);
                    restException.Message = xmlDoc.SelectSingleNode(
                                                                    "TwilioResponse/RestException/Message").InnerText;
                    restException.MoreInfo = xmlDoc.SelectSingleNode(
                                                                     "TwilioResponse/RestException/MoreInfo").InnerText;
                    restException.Status = Convert.ToInt32(
                                                           xmlDoc.SelectSingleNode(
                                                                                   "TwilioResponse/RestException/Status")
                                                                 .InnerText);
                }
                catch (Exception ex)
                {
                    restException = new TwilioException
                                    {
                                        Code = 0,
                                        Message = ex.Message,
                                        MoreInfo = "",
                                        Status = 0
                                    };
                }
                twilioMessage.Status = "failed";
                twilioMessage.RestException = restException;
            }
            else
            {
                try
                {
                    twilioMessage.ReturnSid = xmlDoc.SelectSingleNode(
                                                                      "TwilioResponse/Message/Sid").InnerText;
                    twilioMessage.Created = Convert.ToDateTime(
                                                               xmlDoc.SelectSingleNode(
                                                                                       "TwilioResponse/Message/DateCreated")
                                                                     .InnerText);
                    twilioMessage.Updated = Convert.ToDateTime(
                                                               xmlDoc.SelectSingleNode(
                                                                                       "TwilioResponse/Message/DateUpdated")
                                                                     .InnerText);
                    var sentValue = xmlDoc.SelectSingleNode(
                                                            "TwilioResponse/Message/DateSent");
                    if (sentValue.Value != null)
                    {
                        twilioMessage.Sent = Convert.ToDateTime(
                                                                xmlDoc.SelectSingleNode(
                                                                                        "TwilioResponse/Message/DateSent")
                                                                      .InnerText);
                    }
                    twilioMessage.Direction = xmlDoc.SelectSingleNode(
                                                                      "TwilioResponse/Message/Direction").InnerText;
                    twilioMessage.Status = xmlDoc.SelectSingleNode(
                                                                   "TwilioResponse/Message/Status").InnerText;
                }
                catch (Exception ex)
                {
                }
            }
            return twilioMessage;
        }
    }
}