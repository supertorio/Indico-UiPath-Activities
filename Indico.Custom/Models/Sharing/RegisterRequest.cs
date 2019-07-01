using Newtonsoft.Json;

namespace Indico.Custom.Models
{
    [JsonObject()]
    internal class RegisterRequest : IndicoRequest
    {
        [JsonProperty(PropertyName = "make_public")]
        public bool IsPublic { get; set; }

        public RegisterRequest(string apiKey, string collectionName, bool IsPublic) : base(apiKey, collectionName)
        {
            this.IsPublic = IsPublic;
        }
    }
}
