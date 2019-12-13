using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Indico.Models.Custom
{
    [JsonObject()]
    class IndicoCustomRequest
    {
        [JsonProperty(PropertyName = "api_key")]
        public string APIKey { get; set; }

        [JsonProperty(PropertyName = "collection")]
        public string CollectionName { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

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

        public bool ShouldSerializeVersion()
        {
            return (Version != 0);
        }

        public IndicoCustomRequest(string apiKey)
        {
            this.APIKey = apiKey;
        }

        public IndicoCustomRequest(string apiKey, string collectionName)
        {
            this.APIKey = apiKey;
            this.CollectionName = collectionName;
        }

        public IndicoCustomRequest(string apiKey, string collectionName, object data)
        {
            this.APIKey = apiKey;
            this.CollectionName = collectionName;
            this.Data = data;
        }

        public static StringContent StringContentFromObject(IndicoCustomRequest requestBody)
        {
            string serializedRequest = JsonConvert.SerializeObject(requestBody);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }
    }
}
