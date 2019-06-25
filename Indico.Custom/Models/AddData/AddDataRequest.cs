using Indico.Custom.Enums;
using Indico.Custom.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    [JsonObject()]
    class AddDataRequest : IndicoRequest
    {
        [JsonProperty(PropertyName = "collection")]
        string CollectionName { get; set; }

        [JsonProperty(PropertyName = "domain")]
        [JsonConverter(typeof(StringEnumConverter))]
        ModelDomain Domain { get; set; }

        [JsonProperty(PropertyName = "data")]
        [JsonConverter(typeof(CollectionDataConverter))]
        List<CollectionData> LabeledData { get; set; }

        public AddDataRequest(string apiKey, string collectionName, ModelDomain domain, List<CollectionData> data) : base(apiKey)
        {
            CollectionName = collectionName;
            Domain = domain;
            LabeledData = data;
        }

    }
}
