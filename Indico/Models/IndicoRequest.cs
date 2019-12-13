using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Indico.Models
{
    [JsonObject()]
    class IndicoRequest
    {
        [JsonProperty(PropertyName = "api_key")]
        public string APIKey { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        public IndicoRequest(string apikey)
        {
            this.APIKey = apikey;
        }

        public IndicoRequest(string apikey, string data)
        {
            this.APIKey = apikey;
            this.Data = data;
        }

        public IndicoRequest(string apikey, string data, int version)
        {
            this.APIKey = apikey;
            this.Data = data;
            this.Version = version;
        }

        public static StringContent StringContentFromObject(IndicoRequest requestBody)
        {
            string serializedRequest = JsonConvert.SerializeObject(requestBody);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }

        public bool ShouldSerializeData()
        {
            return this.Data != default;
        }

        public bool ShouldSerializeVersion()
        {
            return this.Version != 0;
        }
    }
}
