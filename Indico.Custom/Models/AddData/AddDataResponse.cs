using Newtonsoft.Json;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class AddDataResponse
    {
        [JsonProperty(PropertyName = "results")]
        public bool Results { get; set; }
    }
}
