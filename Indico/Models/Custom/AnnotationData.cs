using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class AnnotationData
    {
        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public int End { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        public AnnotationData(int start, int end, string label)
        {
            Start = start;
            End = end;
            Label = label;
        }
    }
}
