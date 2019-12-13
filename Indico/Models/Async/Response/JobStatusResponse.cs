using Indico.Enums;
using Newtonsoft.Json;

namespace Indico.Models.Async
{
    [JsonObject()]
    class JobStatusResponse
    {
        public JobStatusResponse(AsyncJobStatus results)
        {
            Results = results;
        }

        [JsonProperty(PropertyName = "results")]
        public AsyncJobStatus Results { get; set; }
    }
}
