using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class CollectionResponse
    {
        [JsonProperty(PropertyName = "results")]
        public CustomCollection Results { get; set; }
    }
}
