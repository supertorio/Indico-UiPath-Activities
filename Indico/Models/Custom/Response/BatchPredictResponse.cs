using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class BatchPredictResponse
    {
        public BatchPredictResponse(List<Dictionary<string, float>> results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public List<Dictionary<string, float>> Results { get; set; }
    }
}
