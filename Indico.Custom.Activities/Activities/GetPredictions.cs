using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetPredictionsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetPredictionsDescription))]
    public class GetPredictions : AsyncTaskCodeActivity<PredictResponse>
    {
        [LocalizedDisplayName(nameof(Resources.ExamplesDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.ExamplesDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.PredictionResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.PredictionResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<Dictionary<string, float>>> Results { get; set; }

        protected override Task<PredictResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var examples = Examples.Get(context);
            return client.GetPredictions(examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, PredictResponse response)
        {
            Results.Set(context, response.Results);
        }
    }
}
