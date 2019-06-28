using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.RemoveCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.RemoveCollectionDescription))]
    public class RemoveCollection : AsyncTaskCodeActivity<SimpleResponse>
    {
        [LocalizedDisplayName(nameof(Resources.RemoveSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.RemoveSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.DeleteCollection();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}
