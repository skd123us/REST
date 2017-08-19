using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rest.Library.Sms
{
    public class TwilioMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string ReturnSid { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Sent { get; set; }
        public string Direction { get; set; }
        public TwilioException RestException { get; set; }
        public string ToMessageString()
        {
            return
                 string.Format(
                         "To={0}&From={1}&Body={2}",
                         To.Replace("+", "%2B"),
                         From.Replace("+", "%2B"),
                         Message.Replace(" ", "+"));
        }

        public void ReadFromConfiguration()
        {
            From = System.Configuration.ConfigurationManager.AppSettings["From"];
            To = System.Configuration.ConfigurationManager.AppSettings["To"];
        }

    }
}
