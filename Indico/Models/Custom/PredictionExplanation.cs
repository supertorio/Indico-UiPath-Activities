using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class PredictionExplanation
    {
        public PredictionExplanation()
        {
        }

        [JsonProperty(PropertyName = "class_confidence")]
        public Dictionary<string, float> ClassConfidence { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }

        [JsonProperty(PropertyName = "explanation")]
        public List<Explanation> Explanation { get; set; }

        [JsonProperty(PropertyName = "prediction")]
        public string Prediction { get; set; }
    }
}
