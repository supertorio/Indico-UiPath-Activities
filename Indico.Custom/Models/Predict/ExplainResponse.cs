using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class Explanation
    {
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "prediction")]
        public string[] Prediction { get; set; }

        [JsonProperty(PropertyName = "similarity")]
        public float Similarity { get; set; }

        [JsonProperty(PropertyName = "target")]
        public string[] Target { get; set; }
    }

    [JsonObject()]
    public class PredictionExplanation
    {
        [JsonProperty(PropertyName = "class_confidence")]
        public Dictionary<string, float> ClassConfidence { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }

        [JsonProperty(PropertyName = "explanation")]
        public List<Explanation> Explanation { get; set; }

        [JsonProperty(PropertyName = "prediction")]
        public string Prediction { get; set; }
    }

    [JsonObject()]
    public class ExplainResponse
    {
        [JsonProperty(PropertyName = "results")]
        public List<PredictionExplanation> Results { get; set; }
    }
}
