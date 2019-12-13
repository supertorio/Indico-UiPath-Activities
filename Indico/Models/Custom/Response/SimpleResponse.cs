using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class SimpleResponse
    {
        public SimpleResponse(bool results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public bool Results { get; set; }
    }
}
