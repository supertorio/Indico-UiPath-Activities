using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Custom.Models
{
    public class CollectionsResponse
    {
        [JsonConverter(typeof(DictionaryToListConverter<CustomCollection>))]
        public List<CustomCollection> results { get; set; }
    }
}
