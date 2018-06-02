using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class SubscriberInfo
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("merge_fields")]
        public MergeFieldInfo MergeFields { get; set; }
    }
}
