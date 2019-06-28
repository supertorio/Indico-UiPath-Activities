using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.RemoveDataDisplayName))]
    [LocalizedDescription(nameof(Resources.RemoveDataDescription))]
    public class RemoveData : AsyncTaskCodeActivity<SimpleResponse>
    {

        [LocalizedDisplayName(nameof(Resources.RemoveExamplesDisplayName))]
        [LocalizedDescription(nameof(Resources.RemoveExamplesDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.RemoveSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.RemoveSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var examples = Examples.Get(context);
            return client.RemoveCollectionData(examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}
