using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Finetune
{
    [JsonObject()]
    public class FinetuneExtraction
    {
        public FinetuneExtraction()
        {
        }

        [JsonProperty(PropertyName = "confidence")]
        public Dictionary<string, float> Confidence { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public int End { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
