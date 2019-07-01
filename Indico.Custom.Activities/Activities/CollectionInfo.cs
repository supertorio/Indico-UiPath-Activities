using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.CollectionInfoDisplayName))]
    [LocalizedDescription(nameof(Resources.CollectionInfoDescription))]
    public class CollectionInfo : AsyncTaskCodeActivity<CollectionResponse>
    {

        [LocalizedDisplayName(nameof(Resources.CollectionInfoResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionInfoResultsDescription))]
        [LocalizedCategory(nameof(Resources.LabeledDataResultsDisplayName))]
        public OutArgument<CustomCollection> Result { get; set; }

        protected override Task<CollectionResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.GetCollection();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, CollectionResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}
