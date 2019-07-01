using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class CollectionsResponse
    {
        [JsonProperty(PropertyName = "results")]
        [JsonConverter(typeof(DictionaryToListConverter<CustomCollection>))]
        public List<CustomCollection> Results { get; set; }
    }
}
