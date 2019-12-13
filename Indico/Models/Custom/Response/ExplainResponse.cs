using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    class ExplainResponse
    {
        public ExplainResponse()
        {
        }

        [JsonProperty(PropertyName = "results")]
        public PredictionExplanation Results { get; set; }
    }
}
