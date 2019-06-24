using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Indico.Pretrained.Models
{
    [JsonObject()]
    public class IndicoRequest
    {
        [JsonProperty(PropertyName = "api_key")]
        public string APIKey { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        public bool ShouldSerializeData()
        {
            return (Data != null);
        }

        public IndicoRequest(string apiKey)
        {
            this.APIKey = apiKey;
        }

        public static StringContent StringContentFromObject(IndicoRequest requestBody)
        {
            string serializedRequest = JsonConvert.SerializeObject(requestBody);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }
    }
}
