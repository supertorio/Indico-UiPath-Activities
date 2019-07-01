using Indico.Custom.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Indico.Custom.Models
{
    [JsonObject()]
    internal class AuthorizeRequest : IndicoRequest
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
