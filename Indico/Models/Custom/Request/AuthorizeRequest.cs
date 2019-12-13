using Indico.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class AuthorizeRequest : IndicoCustomRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }

        [JsonProperty(PropertyName = "permission_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionPermission Permission { get; set; }

        public AuthorizeRequest(string apiKey, string collectionName, string userEmail, CollectionPermission permission) : base(apiKey, collectionName)
        {
            this.UserEmail = userEmail;
            this.Permission = permission;
        }

    }
}
