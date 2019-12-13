using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class AnnotationPrediction
    {
        public AnnotationPrediction()
        {
        }

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
}
