using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Activities.Properties;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetPredictionsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetPredictionsDescription))]
    public class GetPredictions : AsyncTaskCodeActivity<List<Dictionary<string, float>>>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.ExamplesDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.ExamplesDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.PredictionResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.PredictionResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<Dictionary<string, float>>> Results { get; set; }

        protected override Task<List<Dictionary<string, float>>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var examples = Examples.Get(context);
            return client.GetCustomPredictions(collectionName, examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, List<Dictionary<string, float>> response)
        {
            Results.Set(context, response);
        }
    }
}
