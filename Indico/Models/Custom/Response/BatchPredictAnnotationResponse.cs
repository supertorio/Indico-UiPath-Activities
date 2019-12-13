using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class BatchPredictAnnotationResponse
    {
        public BatchPredictAnnotationResponse(List<List<AnnotationPrediction>> results)
        {
            this.Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public List<List<AnnotationPrediction>> Results { get; set; }
    }
}
