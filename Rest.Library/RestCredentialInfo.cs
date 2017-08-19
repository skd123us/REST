namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class RestCredentialInfo
    {
        public string AccountId { get; set; }
        public string SecretKey { get; set; }

        public void ReadFromConfiguration()
        {
            AccountId = System.Configuration.ConfigurationManager.AppSettings["AccountId"];
            SecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
        }
    }
}
