using Indico.Custom;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class CollectionsResponse
    {
        public CollectionsResponse()
        {
        }

        [JsonProperty(PropertyName = "results")]
        [JsonConverter(typeof(DictionaryToListConverter<CustomCollection>))]
        public List<CustomCollection> Results { get; set; }
    }
}
