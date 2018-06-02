using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class Subscriber
    {
        public const string PostUrl = "https://{0}.api.mailchimp.com/3.0/lists/{1}/members/";

        public static async Task<SubscriberInfo> Subscribe(
            RestCredentialInfo restCredentialInfo,
            SubscriberInfo subscriberInfo,
            string listName)
        {
            var restCredential = new Rest(
                "dummy",
                restCredentialInfo.MailChimpApiKey);

            var lists = await Lists.GetLists(restCredentialInfo);
            string listId = string.Empty;
            if (lists != null)
            {
                foreach (ListInfo list in lists.Lists)
                {
                    if (list.Name == listName)
                    {
                        listId = list.Id;
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(listId))
            {
                throw new Exception($"Could not find the list: {listName}");
            }
            var url = string.Format(
                PostUrl,
                restCredentialInfo.MailChimpLocation,
               listId);
            var response = await restCredential.PostAsJsonAsync(
                                    url,
                                    subscriberInfo);
            if (response.IsSuccessStatusCode)
            {

            }
            return null;
        }
    }
}
