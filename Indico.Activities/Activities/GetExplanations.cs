using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Activities.Properties;
using Indico.Models.Custom;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetExplanationsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetExplanationsDescription))]
    public class GetExplanations : AsyncTaskCodeActivity<List<PredictionExplanation>>
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

        [LocalizedDisplayName(nameof(Resources.ExplainResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.ExplainResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<PredictionExplanation>> Results { get; set; }

        protected override Task<List<PredictionExplanation>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var examples = Examples.Get(context);
            return client.GetCustomExplanations(collectionName, examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, List<PredictionExplanation> response)
        {
            Results.Set(context, response);
        }
    }
}
