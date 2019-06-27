using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    [JsonObject()]
    public class PredictResponse
    {
        [JsonProperty(PropertyName = "results")]
        public List<Dictionary<string, float>> Results { get; set; }
    }

    [JsonObject()]
    public class AnnotationPrediction
    {
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public int End { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }

    [JsonObject()]
    public class PredictAnnotationResponse
    {
        [JsonProperty(PropertyName = "results")]
        public List<List<AnnotationPrediction>> Results { get; set; }
    }
}
