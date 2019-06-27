using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Indico.Custom.Models
{
    [JsonObject()]
    class IndicoRequest
    {
        [JsonProperty(PropertyName = "api_key")]
        public string APIKey { get; set; }

        [JsonProperty(PropertyName = "collection")]
        public string CollectionName { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        public bool ShouldSerializeCollectionName()
        {
            return (CollectionName != null);
        }

        public bool ShouldSerializeData()
        {
            return (Data != null);
        }

        public IndicoRequest(string apiKey)
        {
            this.APIKey = apiKey;
        }

        public IndicoRequest(string apiKey, string collectionName)
        {
            this.APIKey = apiKey;
            this.CollectionName = collectionName;
        }

        public IndicoRequest(string apiKey, string collectionName, object data)
        {
            this.APIKey = apiKey;
            this.CollectionName = collectionName;
            this.Data = data;
        }

        public static StringContent StringContentFromObject(IndicoRequest requestBody)
        {
            string serializedRequest = JsonConvert.SerializeObject(requestBody);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }
    }
}
