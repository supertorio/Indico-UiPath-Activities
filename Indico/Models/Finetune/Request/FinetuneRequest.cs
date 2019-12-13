using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Indico.Models.Finetune
{
    [JsonObject()]
    class FinetuneRequest
    {
        [JsonProperty(PropertyName = "api_key")]
        public string APIKey { get; set; }

        [JsonProperty(PropertyName = "collection_name")]
        public string CollectionName { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        [JsonProperty(PropertyName = "job")]
        public bool StartJob { get; set; }

        public bool ShouldSerializeData()
        {
            return (Data != null);
        }

        public bool ShouldSerializeStartJob()
        {
            return (StartJob);
        }

        public FinetuneRequest(string apiKey, string collectionName)
        {
            this.APIKey = apiKey;
            this.CollectionName = collectionName;
            this.Version = 2;
        }

        public static StringContent StringContentFromObject(FinetuneRequest requestBody)
        {
            string serializedRequest = JsonConvert.SerializeObject(requestBody);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }
    }
}
