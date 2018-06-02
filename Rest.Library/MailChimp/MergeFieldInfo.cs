using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class MergeFieldInfo
    {
        [JsonProperty("FNAME")]
        public string FirstName { get; set; }

        [JsonProperty("LNAME")]
        public string LastName { get; set; }
    }
}
