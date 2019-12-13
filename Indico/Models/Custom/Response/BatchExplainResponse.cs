using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    class BatchExplainResponse
    {
        public BatchExplainResponse()
        {
        }

        [JsonProperty(PropertyName = "results")]
        public List<PredictionExplanation> Results { get; set; }
    }
}
