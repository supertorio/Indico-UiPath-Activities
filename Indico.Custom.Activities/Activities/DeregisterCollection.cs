using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.DeregisterCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.DeregisterCollectionDescription))]
    public class DeregisterCollection : AsyncTaskCodeActivity<SimpleResponse>
    {

        [LocalizedDisplayName(nameof(Resources.DeregisterSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.DeregisterSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.DeregisterCollection();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}
