using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetAnnotationsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetAnnotationsDescription))]
    public class GetAnnotations : AsyncTaskCodeActivity<PredictAnnotationResponse>
    {
        [LocalizedDisplayName(nameof(Resources.ExamplesDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.ExamplesDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.AnnotationResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.AnnotationResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<List<AnnotationPrediction>>> Results { get; set; }

        protected override Task<PredictAnnotationResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var examples = Examples.Get(context);
            return client.GetAnnotationPredictions(examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, PredictAnnotationResponse response)
        {
            Results.Set(context, response.Results);
        }
    }
}
