using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class DeAuthorizeRequest : IndicoCustomRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }

        public DeAuthorizeRequest(string apiKey, string collectionName, string userEmail) : base(apiKey, collectionName)
        {
            this.UserEmail = userEmail;
        }
    }
}
