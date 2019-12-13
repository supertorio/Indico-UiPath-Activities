using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    class CollectionResponse
    {
        public CollectionResponse()
        {
        }

        [JsonProperty(PropertyName = "results")]
        public CustomCollection Results { get; set; }
    }
}
