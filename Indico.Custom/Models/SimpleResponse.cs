using Newtonsoft.Json;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class SimpleResponse
    {
        [JsonProperty(PropertyName = "results")]
        public bool Results { get; set; }
    }
}
