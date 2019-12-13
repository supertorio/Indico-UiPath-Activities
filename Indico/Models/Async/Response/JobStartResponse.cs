using Newtonsoft.Json;

namespace Indico.Models.Async
{
    [JsonObject()]
    class JobStartResponse
    {
        public JobStartResponse(string results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public string Results { get; set; }
    }
}
