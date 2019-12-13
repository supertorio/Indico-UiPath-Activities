using Indico.Tools;
using Indico.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    class AddDataRequest : IndicoCustomRequest
    {
        [JsonProperty(PropertyName = "domain")]
        [JsonConverter(typeof(StringEnumConverter))]
        ModelDomain? Domain { get; set; }

        [JsonProperty(PropertyName = "data")]
        [JsonConverter(typeof(CollectionDataConverter))]
        List<CollectionData> LabeledData { get; set; }

        public bool ShouldSerializeDomain()
        {
            return Domain != null;
        }

        public AddDataRequest(string apiKey, string collectionName, List<CollectionData> data) : base(apiKey, collectionName)
        {
            LabeledData = data;
        }

        public AddDataRequest(string apiKey, string collectionName, ModelDomain domain, List<CollectionData> data) : base(apiKey, collectionName)
        {
            Domain = domain;
            LabeledData = data;
        }

    }
}
