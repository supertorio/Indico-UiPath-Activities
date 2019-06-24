using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.ListCollectionsDisplayName))]
    [LocalizedDescription(nameof(Resources.ListCollectionsDescription))]
    public class ListCollections : AsyncTaskCodeActivity<CollectionsResponse>
    {

        [LocalizedDisplayName(nameof(Resources.CollectionListResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionListResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<CustomCollection>> Result { get; set; }

        protected override Task<CollectionsResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.GetCollections();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, CollectionsResponse response)
        {
            Result.Set(context, response.results);
        }
    }
}
