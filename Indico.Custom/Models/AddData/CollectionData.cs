using Newtonsoft.Json;

namespace Indico.Custom.Models
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

    public class CollectionData
    {
        public string SampleText { get; set; }
        public object Label { get; set; }

        public CollectionData(string text, string label)
        {
            SampleText = text;
            Label = label;
        }

        public CollectionData(string text, string[] labels)
        {
            SampleText = text;
            Label = labels;
        }

        public CollectionData(string text, AnnotationData[] labels)
        {
            SampleText = text;
            Label = labels;
        }
    }
}
