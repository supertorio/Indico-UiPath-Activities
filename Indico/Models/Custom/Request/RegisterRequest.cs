using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class RegisterRequest : IndicoCustomRequest
    {
        [JsonProperty(PropertyName = "make_public")]
        public bool IsPublic { get; set; }

        public RegisterRequest(string apiKey, string collectionName, bool IsPublic) : base(apiKey, collectionName)
        {
            this.IsPublic = IsPublic;
        }
    }
}
