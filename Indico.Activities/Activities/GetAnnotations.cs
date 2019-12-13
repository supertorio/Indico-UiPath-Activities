using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Activities.Properties;
using Indico.Models.Custom;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetAnnotationsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetAnnotationsDescription))]
    public class GetAnnotations : AsyncTaskCodeActivity<List<List<AnnotationPrediction>>>
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

        [LocalizedDisplayName(nameof(Resources.AnnotationResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.AnnotationResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<List<AnnotationPrediction>>> Results { get; set; }

        protected override Task<List<List<AnnotationPrediction>>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var examples = Examples.Get(context);
            return client.GetCustomAnnotationPredictions(collectionName, examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, List<List<AnnotationPrediction>> response)
        {
            Results.Set(context, response);
        }
    }
}
