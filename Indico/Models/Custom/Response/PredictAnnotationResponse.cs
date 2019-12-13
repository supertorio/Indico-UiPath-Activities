using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.Custom
{
    [JsonObject()]
    internal class PredictAnnotationResponse
    {
        public PredictAnnotationResponse(List<AnnotationPrediction> results)
        {
            Results = results ?? throw new System.ArgumentNullException(nameof(results));
        }

        [JsonProperty(PropertyName = "results")]
        public List<AnnotationPrediction> Results { get; set; }
    }
}
