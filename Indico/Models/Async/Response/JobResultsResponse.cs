using Newtonsoft.Json;

namespace Indico.Models.Async
{
    [JsonObject()]
    class JobResultsResponse<T>
    {
        public JobResultsResponse(T results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public T Results { get; set; }
    }
}
