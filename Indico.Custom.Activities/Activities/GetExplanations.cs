using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetExplanationsDisplayName))]
    [LocalizedDescription(nameof(Resources.GetExplanationsDescription))]
    public class GetExplanations : AsyncTaskCodeActivity<ExplainResponse>
    {

        [LocalizedDisplayName(nameof(Resources.ExamplesDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.ExamplesDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.ExplainResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.ExplainResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<PredictionExplanation>> Results { get; set; }

        protected override Task<ExplainResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var examples = Examples.Get(context);
            return client.GetExplanations(examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, ExplainResponse response)
        {
            Results.Set(context, response.Results);
        }
    }
}
