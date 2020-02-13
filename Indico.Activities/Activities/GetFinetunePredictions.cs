using Indico.Activities.Properties;
using Indico.Models.Finetune;
using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetFinetunePredictionsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetFinetunePredictionsDescription))]
    public class GetFinetunePredictions : AsyncTaskCodeActivity<List<List<FinetuneExtraction>>>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.FinetuneModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.FinetuneModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.ExamplesDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.ExamplesDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.PredictionResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.PredictionResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<List<FinetuneExtraction>>> Results { get; set; }

        protected override Task<List<List<FinetuneExtraction>>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var examples = Examples.Get(context);
            return client.GetFinetunePredictions(collectionName, examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, List<List<FinetuneExtraction>> response)
        {
            Results.Set(context, response);
        }
    }
}
