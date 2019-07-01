using Newtonsoft.Json;

namespace Indico.Custom.Models
{
    [JsonObject()]
    internal class DeAuthorizeRequest : IndicoRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }

        public DeAuthorizeRequest(string apiKey, string collectionName, string userEmail) : base(apiKey, collectionName)
        {
            this.UserEmail = userEmail;
        }
    }
}
