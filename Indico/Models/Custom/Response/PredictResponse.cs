using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class PredictResponse
    {
        public PredictResponse(Dictionary<string, float> results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public Dictionary<string, float> Results { get; set; }
    }
}
