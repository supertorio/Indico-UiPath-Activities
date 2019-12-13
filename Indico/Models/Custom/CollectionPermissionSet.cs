using Newtonsoft.Json;

namespace Indico.Models.Custom
{
    [JsonObject()]
    public class CollectionPermissionSet
    {
        public CollectionPermissionSet()
        {
        }

        [JsonProperty(PropertyName = "read")]
        public string[] Read { get; set; }

        [JsonProperty(PropertyName = "write")]
        public string[] Write { get; set; }
    }
}
