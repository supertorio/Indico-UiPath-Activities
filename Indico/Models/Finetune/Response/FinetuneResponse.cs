using Newtonsoft.Json;

namespace Indico.Models.Finetune
{
    [JsonObject()]
    class FinetuneCollectionResponse
    {
        public FinetuneCollectionResponse()
        {
        }

        [JsonProperty(PropertyName = "results")]
        public FinetuneCollection Results { get; set; }
    }
}
