using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class CustomCollection
    {
        public CustomCollection()
        {
        }

        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "input_type")]
        public string InputType { get; set; }

        [JsonProperty(PropertyName = "metrics")]
        public object Metrics { get; set; }

        [JsonProperty(PropertyName = "model_type")]
        public string ModelType { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "number_of_examples")]
        public int NumExamples { get; set; }

        [JsonProperty(PropertyName = "permissions")]
        public CollectionPermissionSet Permissions { get; set; }

        [JsonProperty(PropertyName = "public")]
        public bool IsPublic { get; set; }

        [JsonProperty(PropertyName = "registered")]
        public bool IsRegistered { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public object Warnings { get; set; }
    }
}
