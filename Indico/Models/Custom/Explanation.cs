using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class Explanation
    {
        public Explanation()
        {
        }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "prediction")]
        public object Prediction { get; set; }

        [JsonProperty(PropertyName = "similarity")]
        public float Similarity { get; set; }

        [JsonProperty(PropertyName = "target")]
        public object Target { get; set; }
    }
}
